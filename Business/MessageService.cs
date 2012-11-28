using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Business
{
    public class MessageService
    {

        //renvoit tous les messages
        public List<messages> GetAllMessages()
        {

            bindedinEntities bie = SingletonEntities.Instance;

            // on recupere touts les messages
            var search = from m in bie.messages
                         select m;

            return search.ToList();
        }

        //renvoie le message corespondant à l' id passé en parametre si l'id ne corespond à aucun message on renvoit null
        public messages GetMessageById(int messageId)
        {

            bindedinEntities bie = SingletonEntities.Instance;
            messages messageReturn = new messages();

            // on recupere tous les messages
            var search = from m in bie.messages
                         where m.id.Equals(messageId)
                         select m;
            int i = 0;
            foreach (messages message in search.ToList())
	        {
                i++;
                messageReturn = message;
	        }
            if (i == 0)
            {
                return null;
            }

            return messageReturn;
        }

        //renvoit tous les messages envoyés d'un utilisateur 
        public List<messages> GetMessageBySenderId(int senderId)
        {

            bindedinEntities bie = SingletonEntities.Instance;
            messages messageReturn = new messages();

            // on recupere les messages
            var search = from m in bie.messages
                         where m.sender.Equals(senderId)
                         select m;

            return search.ToList();
        }

        //renvoit tous les messages recus d'un utilisateur 
        public List<messages> GetMessageByRecipientId(int recipientId)
        {

            bindedinEntities bie = SingletonEntities.Instance;
            messages messageReturn = new messages();

            // on recupere les messages
            var search = from m in bie.messages
                         where m.sender.Equals(recipientId)
                         select m;

            return search.ToList();
        }

        //envoit un message
        public void SendMessage()
        {

        }

        //passe un message à "lu"
        public void ReadMessage(int idMessage)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            messages m = GetMessageById(idMessage);
            if (m != null)
            {
                //modele pas encore mise a jour
                //m.isRead = false;
                bie.SaveChanges();
            }

        }



    }
}
