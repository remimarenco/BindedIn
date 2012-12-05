using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Data;

namespace BindedIn
{
    public partial class Invitation : System.Web.UI.Page
    {
        private UserProfile loggedInProfile;
        private UserProfile relationProfile;

        protected void Page_Load(object sender, EventArgs e)
        {
            loggedInProfile = UserProfile.GetUserProfile(User.Identity.Name);
            
            // TODO : Passer en paramètre l'id de l'utilisateur avec qui l'on veut etre en relation
            String idUser = Request.Params["id"];
            relationProfile = UserProfile.GetUserProfile(idUser);
            nearRelationFirstName.Text = relationProfile.FirstName;

            message.Text = String.Format("Je vous invite à faire partie de mon réseau professionnel sur BindedIn. {0} {1}", loggedInProfile.FirstName, loggedInProfile.LastName);
        }

        protected void envoyerInvitation_Click(object sender, EventArgs e)
        {
            Business.RelationService.SendInvitation(User.Identity.Name, Request.Params["id"], message.Text);
            Response.Redirect(String.Format("Profil.aspx?id={0}", Request.Params["id"]));
        }
    }
}