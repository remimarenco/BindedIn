using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
using Business;
using System.Web.Security;

namespace BindedIn
{
    public partial class Message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //on vérifie si un utilisteur est connecté
            if(User.Identity.IsAuthenticated)
            {
                List<message> listM = new List<message>();

                //on affiche en fonction du parametres les messages envoyés ou recus
                if (Request.Params["mode"] != null && Request.Params["mode"] == "env")// si on est en mode "messages envoyés"
                {
                    //on recupere le parametre "del" pour voir si il y a un message à effacer
                    if (Request.Params["del"] != null && Convert.ToInt16(Request.Params["del"]) != 0)
                    {
                        MessageService.deleteMessage(Convert.ToInt16(Request.Params["del"]),2);
                        not.Text = "Message effacé";
                    }

                    modeTitle.InnerText = "Messages envoyés";
                    autreMode.InnerText = "Messages reçus";
                    autreMode.HRef = "Message.aspx";
                    listM = MessageService.GetMessageBySenderId((Guid)Membership.GetUser(User.Identity.Name, false).ProviderUserKey);
                    if (listM.Count > 0)
                    {
                        //o utilise le template pour les messages envoyés
                        rptEnv.DataSource = MessageService.MessageToMessagePlus(listM," ");
                        rptEnv.DataBind();
                    }
                    else
                    {
                        errorMessage("Aucun message à afficher");
                    }
                }
                else // si on est en mode "messages recus"
                {
                    //on recupere le parametre "del" pour voir si il y a un message à effacer
                    if (Request.Params["del"] != null && Convert.ToInt16(Request.Params["del"]) != 0)
                    {
                        MessageService.deleteMessage(Convert.ToInt16(Request.Params["del"]), 1);
                        not.Text = "Message effacé";
                    }

                    //on modifie le titre de la page
                    modeTitle.InnerText = "Messages reçus";
                    autreMode.InnerText = "Messages envoyés";
                    autreMode.HRef = "Message.aspx?mode=env";
                    listM = MessageService.GetMessageByRecipientId((Guid)Membership.GetUser(User.Identity.Name, false).ProviderUserKey);
                    if (listM.Count > 0)
                    {
                        //o utilise le template pour les messages recus
                        rptRece.DataSource = MessageService.MessageToMessagePlus(listM,"reception");
                        rptRece.DataBind();
                    }
                    else
                    {
                        errorMessage("Aucun message à afficher");
                    }
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