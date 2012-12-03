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

        /*private message m = new message();

        protected void Page_Load(object sender, EventArgs e)
        {

            //on vérifie si un utilisteur est connecté
            if (User.Identity.IsAuthenticated)
            {
                //si un id est passé en parametre on affiche le message
                if (Request.Params["id"] != null)
                {
                    //on recupere le message
                    m = MessageService.GetMessageById(Convert.ToInt16(Request.Params["id"]));

                    if (m != null)
                    {
                        user u= UserService.GetUtilisateurById(m.sender);


                        //on remplit le destinataire
                        destinataireM.Text = u.firstname+ " "+u.lastname;

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


        //fonction qui redirige vers le formulaire de réponse
        protected void repondreButton_Click(object sender, EventArgs e)
        {
            //on redirige 
            Response.Redirect("MessageForm.aspx?response=" + m.id); 
        }

        //fonction qui supprime le message
        protected void supprimerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Message.aspx"); 
        }*/


    }
}