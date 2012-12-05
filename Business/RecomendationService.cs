using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
namespace Business
{
    public class RecomendationService
    {

        public static recommandation getRecommandationsById(int id)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            recommandation re = new recommandation();

            // on recupere les messages
            var search = from r in bie.recommandations
                         where r.id.Equals(id)
                         select r;
            foreach (recommandation r in search.ToList())
            {
                re = r;
            }
            return re;
        }
        public static List<recommandation> getRecommandations(Guid user)
        {
            bindedinEntities bie = SingletonEntities.Instance;

            // on recupere les messages
            var search = from r in bie.recommandations
                         where r.recipient.Equals(user)
                         select r;

            return search.ToList();
        }

        //envoit une recommandations
        public static void SendRecommandation(Guid sender, Guid recipient, string me)
        {
            bindedinEntities bie = SingletonEntities.Instance;

            //on creait une nouvelle recommandation
            recommandation r = new recommandation();
            r.sender = sender;
            r.recipient = recipient;
            r.message = me;

            //on sauvegarde le message dans la base
            bie.recommandations.AddObject(r);
            bie.SaveChanges();

        }

        public static List<RecommandationPlus> RecommandationToRecommandationPlus(List<recommandation> listR)
        {
            List<RecommandationPlus> listRP = new List<RecommandationPlus>();

            if (listR != null)
            {
                foreach (recommandation r in listR)
                {
                    listRP.Add(new RecommandationPlus(r));
                }
            }

            return listRP;
        }

        
    }
}
