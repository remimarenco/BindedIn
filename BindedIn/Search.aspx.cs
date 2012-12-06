using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
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
                List<UserProfile> listUP_mod = new List<UserProfile>();
                Guid userGuid;

                foreach (UserProfile up in listUP)
                {
                    userGuid = (Guid)Membership.GetUser(up.UserName, false).ProviderUserKey;
                    up.imageUrl = "/ShowImage.ashx?iduser=" + userGuid.ToString();
                    // Fix cache issues
                    up.imageUrl += "&tmp=" + DateTime.Now;
                    listUP_mod.Add(up);

                }
                if (listUP.Count > 0)
                {
                    rpt1.DataSource = listUP_mod;
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