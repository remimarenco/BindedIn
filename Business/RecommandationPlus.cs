using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Business
{
    public class RecommandationPlus
    {
        public int id { get; set; }
        public Guid sender { get; set; }
        public Guid recipient { get; set; }
        public string message { get; set; }
        public string senderName { get; set; }
        public string recipientName { get; set; }

        public RecommandationPlus(recommandation r)
        {
            this.message = r.message;
            this.sender = r.sender;
            this.recipient = r.recipient;
            this.id = r.id;

            UserProfile up = UserProfile.GetUserProfile(UserService.GetUtilisateurById(this.sender).UserName);
            this.senderName = up.FirstName + " " + up.LastName;

            up = UserProfile.GetUserProfile(UserService.GetUtilisateurById(this.recipient).UserName);
            this.recipientName = up.FirstName + " " + up.LastName;
        }
    }
}
