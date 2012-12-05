using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Data;
using Business;

namespace BindedIn
{
    public partial class MonCompte : System.Web.UI.Page
    {
        UserProfile Profile;
        Guid UserId;
        protected void Page_Load(object sender, EventArgs e)
        {
            
                Profile = UserProfile.GetUserProfile(User.Identity.Name);
                UserId = (Guid)(Membership.GetUser(User.Identity.Name, false).ProviderUserKey);
                ObjectDataSourceImage.SelectParameters["userId"].DefaultValue = UserId.ToString();
                photoAlert.Visible = false;            
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
            {
                byte[] imageSize = new byte [FileUpload1.PostedFile.ContentLength];
                HttpPostedFile uploadedImage = FileUpload1.PostedFile;
                uploadedImage.InputStream.Read
                   (imageSize, 0, (int)FileUpload1.PostedFile.ContentLength);

                int result = ImagesService.addNewImage((Guid) Membership.GetUser(User.Identity.Name, false).ProviderUserKey, imageSize);
                if (result > 0)
                {
                    photoAlert.Attributes.Add("class", "alert alert-success");
                    photoAlertText.InnerText = "Votre nouvelle photo de profil a bien été envoyée !";
                    ObjectDataSourceImage.Update();
                }
                else
                {
                    photoAlert.Attributes.Add("class", "alert alert-error");
                    photoAlertText.InnerText = "Une erreur s'est produite, le transfert à échoué.";
                }
                photoAlert.Visible = true;
            }
        }

        public string DisplaySpanCurrent(Object current)
        {
            if ( (Boolean) current )
                return "<span class=\"label label-success current-img\">Actuelle</span>";
            return "";
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            if (idImageSelected.Value != "")
            {
                Business.ImagesService.setImageAsCurrent(Int32.Parse(idImageSelected.Value), (Guid)Membership.GetUser(User.Identity.Name, false).ProviderUserKey);
                ObjectDataSourceImage.Update();
                photoAlert.Attributes.Add("class", "alert alert-success");
                photoAlertText.InnerText = "La photo de profil a bien été changée !";
            }
            else
            {
                photoAlert.Attributes.Add("class", "alert alert-info");
                photoAlertText.InnerText = "Vous devez sélectionner une photo.";
            }
            photoAlert.Visible = true;
        }

        protected void btnDeleteImg_Click(object sender, EventArgs e)
        {
            if (idImageSelected.Value != "")
            {
                Business.ImagesService.deleteImage(Int32.Parse(idImageSelected.Value), (Guid)Membership.GetUser(User.Identity.Name, false).ProviderUserKey);
                ObjectDataSourceImage.Update();
                photoAlert.Attributes.Add("class", "alert alert-success");
                photoAlertText.InnerText = "La photo a été supprimée.";
            }
            else
            {
                photoAlert.Attributes.Add("class", "alert alert-info");
                photoAlertText.InnerText = "Vous devez sélectionner une photo.";
            }
            photoAlert.Visible = true;
            
        }
    }
}