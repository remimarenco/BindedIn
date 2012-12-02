using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Business
{
    public class RelationService
    {      

        public static List<user> GetRelations(int userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var retour = from u in bie.users from c in bie.relation_status from s in bie.status_name

                                where c.asked_user.Equals(userId) || c.asking_user.Equals(userId) 
                                 where u.id.Equals(c.asked_user) || u.id.Equals(c.asking_user)
                                 where s.id.Equals(c.status)
                                 //where s.status.Equals("Confirmed")
                                 select u;
        
            return retour.ToList();
        }

    }
}
