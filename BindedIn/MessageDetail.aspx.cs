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

        private message m = new message();

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

                        if (User.Identity.Name == UserService.GetUtilisateurById(m.sender).UserName || User.Identity.Name == UserService.GetUtilisateurById(m.recipient).UserName)
                        {
                            if (User.Identity.Name == UserService.GetUtilisateurById(m.recipient).UserName)
                            {
                                //on passe le message a "lu"
                                MessageService.ReadMessage(m.id);
                            }

                            //on recupre le username a partir d'un guid
                            string username = UserService.GetUtilisateurById(m.sender).UserName;

                            //on recupere le userprofile a partir du username
                            UserProfile u = UserProfile.GetUserProfile(username);


                            //on remplit le destinataire
                            destinataireM.Text = u.FirstName + " " + u.LastName;

                            //on remplit le champ objet
                            objectM.Text = m.@object;

                            //on remplit le corps du message
                            message.Text = m.message1;

                            // Date
                            dateMessage.InnerText = String.Format("{0:dd MMMM yyyy}", m.date);

                            //affichage de l'image
                            string uId = m.sender.ToString();
                            ImageProfile.ImageUrl = "/ShowImage.ashx?iduser=" + uId;
                            // Fix cache issues
                            ImageProfile.ImageUrl += "&tmp=" + DateTime.Now;

                            //on remplit les liens
                            lienDestinataire1.HRef = "Profil.aspx?id=" + u.UserName;
                            lienDestinataire2.HRef = "Profil.aspx?id=" + u.UserName;
                        }
                        else
                        {
                            errorMessage("Vous n'avez pas acces à ce message");
                        }


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
            Response.Redirect("Message.aspx?del=" + m.id); 
        }


    }
}