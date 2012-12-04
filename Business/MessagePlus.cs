using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

//classe creée pour contenir les nom des utilisateurs (sender et receipter) grace aux guid
namespace Business
{
    public class MessagePlus
    {



        public int id { get; set; }
        public int isRead { get; set; }
        public string date { get; set; }
        public string @object { get; set; }
        public string message1 { get; set; }
        public string senderName { get; set; }
        public string recipientName { get; set; }
        public Guid sender { get; set; }
        public Guid recipient { get; set; }
        

        public MessagePlus(message m)
        {
            this.isRead = m.isRead;
            this.id = m.id;
            this.date = String.Format("{0:dd/MM/yyyy}", m.date);
            this.sender = m.sender;
            this.recipient = m.recipient;
            this.@object = m.@object;
            this.message1 = m.message1;


            UserProfile up = UserProfile.GetUserProfile(UserService.GetUtilisateurById(this.sender).UserName);
            this.senderName = up.FirstName + " " + up.LastName;

            up = UserProfile.GetUserProfile(UserService.GetUtilisateurById(this.recipient).UserName);
            this.recipientName = up.FirstName + " " + up.LastName;

        }

    }
}
