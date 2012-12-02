using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Business
{
    public class ProfessionalExpService
    {

        public static List<professional_experience> GetProferssionalExp()
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var formations = from c in bie.professional_experience
                        select c;
            return formations.ToList();
        }

        public static List<professional_experience> GetProferssionalExp(int userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var retour = from ue in bie.user_experienceprofessional from p in bie.professional_experience
                                 where ue.user.Equals(userId)
                                 where ue.experience_professional.Equals(p.id)
                                 select p;
        
            return retour.ToList();
        }

    }
}
