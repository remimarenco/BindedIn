using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Business
{
    public class Relations
    {
        public static List<Data.users> getRelationsOfId(int id)
        {
            bindedinEntities bie = SingletonEntities.Instance;

            // On récupère les utilisateurs qui sont en relation 
            var relations = from rel in bie.relation_status
                            where rel.status == 3
                            select rel;

            List<users> userRelations = new List<users>();
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
