using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using System.Security.Principal;

namespace Business
{
    public class Relations
    {
        public static List<Data.user> getRelationsOfId(int id)
        {
            bindedinEntities bie = SingletonEntities.Instance;

            UserProfile profile = UserProfile.GetUserProfile(System.Web.HttpContext.Current.User.Identity.Name);

            // On récupère les utilisateurs qui sont en relation 
            var relations = from rel in bie.relation_status
                            where rel.status == 3
                            select rel;

            List<user> userRelations = new List<user>();
            foreach (var relation in relations)
            {
                if (relation.status == 3)
                {
                    if (relation.asked_user == id)
                    {
                        userRelations.Add(relation.user_asking);
                    }
                    else if(relation.asking_user == id)
                    {
                        userRelations.Add(relation.user_asked);
                    }
                }
            }
            return userRelations;
        }
    }
}
