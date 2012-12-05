using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Data;
using Business;

namespace BindedIn
{
    public partial class RecommandationForm : System.Web.UI.Page
    {
        string recId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //on vérifie si un utilisteur est connecté
            if (User.Identity.IsAuthenticated)
            {
                //on verifie si le message à déja été envoyé
                if (Request.Params["envoye"] == "1")
                {
                    errorMessage("Recommandation Envoyée");
                }
                else
                {
                    string p = Request.Params["id"];
                    //si un id est passé on affiche le nom du destinataire
                    if (Request.Params["id"] != null)
                    {
                        //on recupere le userprofile a prtir de l'id
                        UserProfile u = UserProfile.GetUserProfile(Request.Params["id"]);

                        recId = u.UserName;

                        //on remplit le champ destinataire
                        recipientLabel.Text = u.FirstName + " " + u.LastName;
                    }
                    else
                    {
                        errorMessage("Erreur mauvais parametres");
                    }
                }

            }
            else
            {
                errorMessage("Vous devez vous connecter");
            }
        }

        // function qui affichage un message
        protected void errorMessage(string me)
        {
            //on cache les div de form du message
            recommandationForm.Visible = false;
            //on affiche le message
            not.Text = me;
        }
        protected void envoyerButton_Click(object sender, EventArgs e)
        {

            RecomendationService.SendRecommandation((Guid)Membership.GetUser(User.Identity.Name, false).ProviderUserKey, (Guid)Membership.GetUser(recId, false).ProviderUserKey, message.InnerText);
            Response.Redirect("~/RecommandationForm.aspx?envoye=1");

        }
    }
}