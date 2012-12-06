using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using System.Globalization;
using System.Data;

namespace Business
{
    public class FormationService
    {

        public static List<formation> GetFormations()
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var formations = from c in bie.formations
                        select c;
            return formations.ToList();
        }

        public static List<formation> GetFormations(Guid userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var retour = from uf in bie.user_formation from f in bie.formations
                                 where uf.user.Equals(userId)
                                 where uf.formation.Equals(f.id)
                                 select f;
            
            return retour.ToList();
        }

        public static List<v_formation_schools1> GetFormationSchools(Guid userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var retour = from uf in bie.user_formation
                         from f in bie.v_formation_schools1
                         where uf.user.Equals(userId)
                         where uf.formation.Equals(f.id)
                         select f;

            return retour.ToList();
        }
        
        public static void InsertNewFormation(String nom,
            String description, String dateDebut, String dateFin, String etablissement,Guid userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;

            var existingFormation = from f in bie.formations from s in bie.schools
                                    where f.name.Equals(nom)                                
                                    where f.school.Equals(s.id)
                                    where s.name.Equals(etablissement)
                                    select f;

            if (existingFormation.Count() == 0)
            {

                formation ord = new formation
                {
                    name = nom,
                    description = description,                   
                    school = Business.SchoolsService.InsertSchool(etablissement, ""),

                };
                bie.formations.AddObject(ord);
                bie.SaveChanges();

            }

            var idFormation = from f in bie.formations
                              where f.name.Equals(nom)
                              where f.description.Equals(description)
                              select f.id;

            user_formation uf = new user_formation
            {
                user=userId,
                formation=idFormation.First(),
                beginning_date = DateTime.Parse(dateDebut, CultureInfo.CreateSpecificCulture("en-US")),
                end_date = DateTime.Parse(dateFin, CultureInfo.CreateSpecificCulture("en-US")),
            };
            bie.user_formation.AddObject(uf);          
            bie.SaveChanges();
           
        }

        public static void Remove(string p, Guid userid)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            int id = Int32.Parse(p);

            var retour = from i in bie.user_formation
                         where i.formation.Equals(id)
                         && i.user.Equals(userid)
                         select i;
            foreach (user_formation exp in retour)
            {
                bie.user_formation.DeleteObject(exp);
            }
            bie.SaveChanges();
        }

    }
}
