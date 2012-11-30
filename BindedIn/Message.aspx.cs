using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
using Business;

namespace BindedIn
{
    public partial class Message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //on vérifie si un utilisteur est connecté
            if(User.Identity.IsAuthenticated)
            {
                rpt1.DataSource = MessageService.GetMessageByRecipientId(1);
                rpt1.DataBind();
            }
        }

        protected void rpt1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}