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
        public List<message> GetAllMessages()
        {

            bindedinEntities bie = SingletonEntities.Instance;

            // on recupere touts les messages
            var search = from m in bie.messages
                         select m;

            return search.ToList();
        }

        //renvoie le message corespondant à l' id passé en parametre si l'id ne corespond à aucun message on renvoit null
        public message GetMessageById(int messageId)
        {

            bindedinEntities bie = SingletonEntities.Instance;
            message messageReturn = new message();

            // on recupere tous les messages
            var search = from m in bie.messages
                         where m.id.Equals(messageId)
                         select m;
            int i = 0;
            foreach (message message in search.ToList())
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
        public List<message> GetMessageBySenderId(int senderId)
        {

            bindedinEntities bie = SingletonEntities.Instance;
            message messageReturn = new message();

            // on recupere les messages
            var search = from m in bie.messages
                         where m.sender.Equals(senderId)
                         select m;

            return search.ToList();
        }

        //renvoit tous les messages recus d'un utilisateur 
        public static List<message> GetMessageByRecipientId(int recipientId)
        {

            bindedinEntities bie = SingletonEntities.Instance;
            message messageReturn = new message();

            // on recupere les messages
            var search = from m in bie.messages
                         where m.recipient.Equals(recipientId)
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
            message m = GetMessageById(idMessage);
            if (m != null)
            {
                //modele pas encore mise a jour
                m.isRead = 1;
                bie.SaveChanges();
            }

        }


        //efface le message correspondant à l'id passé en parametre
        public void deleteMessage(int messageId)
        {
            bindedinEntities bie = SingletonEntities.Instance;

            //on recupere le messge à effacer
            var deleteMessages = from m in bie.messages where m.id.Equals(messageId) select m;

            foreach (var me in deleteMessages)
            {
                //on efface
                bie.messages.DeleteObject(me);
            }

            try
            {
                //on sauvergarde les modifs
                bie.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }



    }
}
