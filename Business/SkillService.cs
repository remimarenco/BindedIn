using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using System.Data;

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

        public static List<v_user_competences> GetSkillsUser(Guid userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var retour = from uc in bie.user_competence
                         from c in bie.v_user_competences
                         orderby c.level descending, c.name ascending
                         where uc.user.Equals(userId)
                         where uc.competence.Equals(c.id)
                         select c;

            return retour.ToList();
        }

        public static void InsertNewSkill(String name, String description, int level,Guid userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var existing = from c in bie.competences
                           where c.description.Equals(description)
                           where c.name.Equals(name)
                           select c;
            if (existing.Count() == 0)
            {
                competence comp = new competence
                {
                    name=name,
                    description=description
                };

                bie.competences.AddObject(comp);
                bie.SaveChanges();
            }

            var idComp = from c in bie.competences
                              where c.name.Equals(name)
                              where c.description.Equals(description)
                              select c.id;

            user_competence uc = new user_competence
            {
                user=userId,
                competence=idComp.First(),
                level=level,
            };

            bie.user_competence.AddObject(uc);          
            bie.SaveChanges();
     
        }

    }
}
