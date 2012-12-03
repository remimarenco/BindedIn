using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace BindedIn
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*//on recupere le parametre de recherche
            string keyWords = Request.Params["se"];

            //si un parametre est passé on lance la recherche puis on affiche
            if (keyWords != null)
            {
                rpt1.DataSource = SearchService.SearchUser(keyWords);
                rpt1.DataBind();
            }*/
        }
    }
}