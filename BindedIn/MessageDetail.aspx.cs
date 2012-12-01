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
    public partial class MessageDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //on vérifie si un utilisteur est connecté
            if (User.Identity.IsAuthenticated)
            {
                //on recupere l'id du message
                int messageId = Convert.ToInt16(Request.Params["id"]);

                //si un parametre est passé on affiche le message
                if (messageId != null)
                {
                    //on recupere le message
                    message m = MessageService.GetMessageById(messageId);

                    if (m != null)
                    {
                        //on remplit le champ objet
                        objectM.Text = m.@object;

                        //on remplit le corps du message
                        message.Text = m.message1;

                    }
                    else
                    {
                        errorMessage("Aucun message correspondant");
                    }

                }
                else
                {
                    errorMessage("Aucun message correspondant");
                }
            }
            else
            {
                errorMessage("Vous devez vous connecter");
            }
        }

        protected void errorMessage(string me)
        {
            //on cache les div de detail du message
            messageD.Visible = false;
            //on affiche le message
            not.Text =me;
        }
    }
}