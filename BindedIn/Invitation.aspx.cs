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
            relationProfile = UserProfile.GetUserProfile(Request.Params["id"]);
            nearRelationFirstName.Text = relationProfile.FirstName;

            message.Text = String.Format("Je vous invite à faire partie de mon réseau professionnel sur BindedIn. {0} {1}", loggedInProfile.FirstName, loggedInProfile.LastName);
        }

        protected void envoyerInvitation_Click(object sender, EventArgs e)
        {
            String obj = String.Format("{0} {1} veut vous inviter dans son réseau !", loggedInProfile.FirstName, loggedInProfile.LastName);

            String messageToSend = message.Text;

            messageToSend += "\n";

            Uri uri = HttpContext.Current.Request.Url;
            String host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
            String linkForInvitation = host + String.Format("/AcceptedInvitation.aspx?id_asked={0}&id__asking={1}", (Guid)(Membership.GetUser(User.Identity.Name, false).ProviderUserKey), (Guid)(Membership.GetUser(Request.Params["id"], false).ProviderUserKey));

            messageToSend += String.Format("Voici le lien pour accepter cette invitation : {0}", linkForInvitation);
            messageToSend += "\n";
            messageToSend += "Sinon ignorez tout simplement ce message";
            messageToSend += "\nCordialement,";
            messageToSend += "\nVotre équipe BindedIn";

            Business.MessageService.SendMessage((Guid)(Membership.GetUser(User.Identity.Name, false).ProviderUserKey), (Guid)(Membership.GetUser(Request.Params["id"], false).ProviderUserKey), obj, messageToSend);

            Response.Redirect(String.Format("Profil.aspx?id={0}", Request.Params["id"]));
        }
    }
}