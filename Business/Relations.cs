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
                            where rel.status == 3 && 
                            (
                                id == rel.asking_user
                                ||
                                id == rel.asked_user
                            )
                            select rel;

            List<users> relationsWithout = new List<users>();
            foreach (var relation in relations)
            {
                if (relation.asked_user == id)
                {
                    relationsWithout.Add(relation.user_asking);
                }
                else
                {
                    relationsWithout.Add(relation.user_asked);
                }
            }
            return relationsWithout;
        }
    }
}
