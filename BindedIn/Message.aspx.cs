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
                List<message> listM = MessageService.GetMessageByRecipientId(1);

                if (listM.Count > 0)
                {
                    rpt1.DataSource = MessageService.GetMessageByRecipientId(1);
                    rpt1.DataBind();
                }
                else
                {
                    errorMessage("Aucun message a afficher");
                }
            }
        }

        // function qui affichage un message
        protected void errorMessage(string me)
        {
            //on cache les div de detail du message
            messageList.Visible = false;
            //on affiche le message
            not.Text = me;
        }

        protected void rpt1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}