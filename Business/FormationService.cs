using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Business
{
    public class FormationService
    {

        public static List<Data.formations> GetFormations()
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var formations = from c in bie.formations
                        select c;
            return formations.ToList();
        }

        public static List<Data.formations> GetFormations(int userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var retour = from uf in bie.user_formation from f in bie.formations
                                 where uf.user.Equals(userId)
                                 where uf.formation.Equals(f.id)
                                 select f;
        
            return retour.ToList();
        }

    }
}
