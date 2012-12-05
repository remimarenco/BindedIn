using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using System.Web.Security;
using Data;
using Business;

namespace BindedIn
{
    public partial class Recommandation : System.Web.UI.Page
    {
        public string userName;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<recommandation> listR = new List<recommandation>();

            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;


                //on recupere le parametre "del" pour voir si il y a un message à effacer
                if (Request.Params["del"] != null && Convert.ToInt16(Request.Params["del"]) != 0)
                {
                    //RecommandationService.deleteRecommandation(Convert.ToInt16(Request.Params["del"]),2);
                    not.Text = "Recommandation effacée";
                }

                listR = RecomendationService.getRecommandations((Guid)Membership.GetUser(userName, false).ProviderUserKey);
                if (listR.Count > 0)
                {
                    //o utilise le template pour les messages envoyés
                    rpt.DataSource = RecomendationService.RecommandationToRecommandationPlus(listR);
                    rpt.DataBind();
                }
                else
                {
                    errorMessage("Aucune recommandation à afficher");
                }

            }
            else
            {
                errorMessage("Erreur");
            }
               


        }
        


        // function qui affichage un message
        protected void errorMessage(string me)
        {
            //on cache les div de detail du message
            recommandationList.Visible = false;
            //on affiche le message
            not.Text = me;
        }
    }
}