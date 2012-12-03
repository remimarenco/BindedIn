using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Business
{
    public class SkillService
    {

        public static List<competence> GetSkills()
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var formations = from c in bie.competences
                        select c;
            return formations.ToList();
        }

        public static List<competence> GetSkills(Guid userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var retour = from uc in bie.user_competence from c in bie.competences
                                 where uc.user.Equals(userId)
                                 where uc.competence.Equals(c.id)
                                 select c;
        
            return retour.ToList();
        }

    }
}
