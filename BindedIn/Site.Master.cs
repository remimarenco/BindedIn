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
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //si l utilisateur est connecté
            if (this.Page.User.Identity.IsAuthenticated)
            {
                //on affiche le nombre de message non lus
                //linkMessage.InnerHtml += MessageService.GetStringCountUnreadMessage((Guid)Membership.GetUser(User.Identity.Name, false).ProviderUserKey);
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string keyWords = searchField.Text;
            Response.Redirect("~/Search.aspx?se=" + keyWords);
        }

        protected void ButLogin_Click(object sender, EventArgs e)
        {

        }

        protected void logout_click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/Default.aspx");
        }

        protected void ButLoginDD_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Account/Login.aspx");
        }

        protected void ButRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Account/Register.aspx");
        }        
    }
}
