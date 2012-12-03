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
    public partial class MessageForm : System.Web.UI.Page
    {

        string recId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //on vérifie si un utilisteur est connecté
            if (User.Identity.IsAuthenticated)
            {
                //on verifie si le message à déja été envoyé
                if (Request.Params["envoye"] == "1")
                {
                    errorMessage("Message Envoyé");
                }
                else
                {
                    string p = Request.Params["id"];
                    //si un id est passé on affiche le nom du destinataire
                    if (Request.Params["id"] != null)
                    {
                        UserProfile u = UserProfile.GetUserProfile(Request.Params["id"]);
                        recId = u.UserName;

                        //on remplit le champ destinataire
                        recipientLabel.Text = u.FirstName + " " + u.LastName;
                    }
                    // si un id de message à repondre est passé
                    else if (Request.Params["response"] != null)
                    {
                        //on recupere le message auquel il faut répondre
                        message m = MessageService.GetMessageById(Convert.ToInt16(Request.Params["response"]));
                        //on récupere le sender de ce message pour
                        UserProfile u = UserProfile.GetUserProfile(m.sender.ToString());
                        recId = u.UserName;

                        //on remplit le champ objet
                        objectTextBox.Text = "RE: " + m.@object;

                        //on remplit le champ destinataire
                        recipientLabel.Text = u.FirstName + " " + u.LastName;


                    }
                    else
                    {
                        errorMessage("Erreur mauvais parametres");
                    }
                }

            } else
            {
                errorMessage("Vous devez vous connecter");
            }
            
        }

        protected void envoyerButton_Click(object sender, EventArgs e)
        {

            MessageService.SendMessage((Guid)Membership.GetUser(User.Identity.Name, false).ProviderUserKey, (Guid)Membership.GetUser(recId, false).ProviderUserKey, objectTextBox.Text, message.Text);
            Response.Redirect("~/MessageForm.aspx?envoye=1");

        }

        // function qui affichage un message
        protected void errorMessage(string me)
        {
            //on cache les div de form du message
            messageForm.Visible = false;
            //on affiche le message
            not.Text = me;
        }
        

    }
}