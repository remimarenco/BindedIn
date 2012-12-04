using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
using System.Web.Security;

namespace BindedIn
{
    public partial class Profil : System.Web.UI.Page
    {
        UserProfile Profile;
        Guid UserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            //editSkills.Visible = false;
            //editExp.Visible = false;
            //editFormation.Visible = false;

            Profile = UserProfile.GetUserProfile(User.Identity.Name);
            UserId = (Guid)(Membership.GetUser(User.Identity.Name, false).ProviderUserKey);

            //LabelNom.Text = Profile.FirstName + " " + Profile.LastName;
            ObjectDataSourceUserProfile.SelectParameters["id"].DefaultValue = UserId.ToString();
            ImageProfile.ImageUrl = "/ShowImage.ashx?id=" + UserId.ToString();
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            if(sender.Equals(ButtonEditSkills))
                editSkills.Visible = true;
            else if (sender.Equals(ButtonEditFormation))
                editFormation.Visible = true;
            else if (sender.Equals(ButtonEditExp))
                editExp.Visible = true;
        }
    }
}