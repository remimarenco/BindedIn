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
    public partial class RecommandationDetail : System.Web.UI.Page
    {
        string userName;
        recommandation r;
        protected void Page_Load(object sender, EventArgs e)
        {
            //on vérifie si un utilisteur est connecté
            if (User.Identity.IsAuthenticated)
            {
                //si un id est passé en parametre on affiche le message
                if (Request.Params["id"] != null)
                {
                    //on recupere le message
                    r = RecomendationService.getRecommandationsById(Convert.ToInt16(Request.Params["id"]));

                    if (r != null)
                    {

                        //on recupre le username a partir d'un guid
                        string username = UserService.GetUtilisateurById(r.sender).UserName;

                        //on recupere le userprofile a partir du username
                        UserProfile u = UserProfile.GetUserProfile(username);


                        //on remplit le destinataire
                        destinataireM.Text = u.FirstName + " " + u.LastName;

                        //on remplit le corps du message
                        message.Text = r.message;

                    }
                    else
                    {
                        errorMessage("Aucune recommandation correspondante");
                    }

                }
                else
                {
                    errorMessage("Aucune recommandation correspondante");
                }
            }
            else
            {
                errorMessage("Vous devez vous connecter");
            }
        }

        //fonction qui supprime la recommandation
        protected void supprimerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Recommandation.aspx?del=" + r.id);
        }
        protected void errorMessage(string me)
        {
            //on cache les div de detail du message
            recommandationD.Visible = false;
            //on affiche le message
            not.Text = me;
        }
    }
}