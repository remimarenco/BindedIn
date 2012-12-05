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
        protected void Page_Load(object sender, EventArgs e)
        {
            UserProfile Profile = UserProfile.GetUserProfile(User.Identity.Name);

            // TODO : Passer en paramètre l'id de l'utilisateur avec qui l'on veut etre en relation
            String idUser = Request.Params["id"];
            // A supprimer
            idUser = Profile.FirstName;
            nearRelationFirstName.Text = idUser;
            
            message.Text = String.Format("Je vous invite à faire partie de mon réseau professionnel sur LinkedIn. {0} {1}", Profile.FirstName, Profile.LastName);
        }

        protected void envoyerInvitation_Click(object sender, EventArgs e)
        {

        }
    }
}