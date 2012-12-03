using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Business
{
    public class RelationService
    {      

        public static List<aspnet_Users> GetRelations(Guid userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;

            UserProfile profile = UserProfile.GetUserProfile(System.Web.HttpContext.Current.User.Identity.Name);

            // On récupère les utilisateurs qui sont en relation 
            var relations = from rel in bie.relation_status
                            where rel.status == 3
                            select rel;

            List<aspnet_Users> userRelations = new List<aspnet_Users>();
            foreach (var relation in relations)
            {
                if (relation.status == 3)
                {
                    if (relation.asked_user == userId)
                    {
                        userRelations.Add(relation.aspnet_asking_users);
                    }
                    else if (relation.asking_user == userId)
                    {
                        userRelations.Add(relation.aspnet_asked_users);
                    }
                }
            }
            return userRelations;
        }

    }
}
