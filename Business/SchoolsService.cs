using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Business
{
    public class SchoolsService
    {

        public static List<school> GetSchools()
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var formations = from c in bie.schools
                        select c;
            return formations.ToList();
        }

        public static List<school> GetSchools(Guid userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var retour = from uf in bie.user_formation from f in bie.formations from sc in bie.schools
                                 where uf.user.Equals(userId)
                                 where uf.formation.Equals(f.id)
                                 where f.school.Equals(sc.id)
                                 select sc;
            
            return retour.ToList();
        }

        public static int InsertSchool(String name, String description)
        {
             bindedinEntities bie = SingletonEntities.Instance;
             var existingSchool = from s in bie.schools
                                  where s.name.Equals(name)
                                  where s.description.Equals(description)
                                  select s;

             if (existingSchool.Count() == 0)
             {

                 school sc = new school
                 {
                     name = name,
                     description = description
                 };

                 bie.AddToschools(sc);
                 bie.SaveChanges();

             }
            var id = from s in bie.schools
                     where s.name.Equals(name)
                     where s.description.Equals(description)
                     select s.id;
            return id.First();
        }

    }
}
