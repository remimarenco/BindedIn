using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Data;

namespace BindedIn
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //on recupere le parametre de recherche
            string keyWords = Request.Params["se"];


            //on affiche les parametres de recherche
            sTitle.Text = "Resultat de la recherche: " + keyWords;
            //si un parametre est passé on lance la recherche puis on affiche
            if (keyWords != null)
            {
                List<UserProfile> listUP = SearchService.SearchUser(keyWords);

                if (listUP.Count > 0)
                {
                    rpt1.DataSource = SearchService.SearchUser(keyWords);
                    rpt1.DataBind();
                }
                else
                {
                    sMessage.Text = "Aucun utilisteur ne correspond à la recherche";
                }
            }


        }
    }
}