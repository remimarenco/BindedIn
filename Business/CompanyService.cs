using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Business
{
    public class CompanyService
    {

        public static List<company> GetCompanies()
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var formations = from c in bie.companies
                        select c;
            return formations.ToList();
        }

        public static List<company> GetCompanies(Guid userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var retour = from uep in bie.user_experienceprofessional from pe in bie.professional_experience from c in bie.companies
                                 where uep.user.Equals(userId)
                                 where uep.experience_professional.Equals(pe.id)
                                 where pe.company.Equals(c.id)
                                 select c;
            
            return retour.ToList();
        }

        public static int InsertCompany(String name, String adresse, String tel)
        {
             bindedinEntities bie = SingletonEntities.Instance;
             var existingCompany = from s in bie.companies
                                  where s.nom.Equals(name)
                                  where s.adresse.Equals(adresse)
                                  where s.telephone.Equals(tel)
                                  select s;

             if (existingCompany.Count() == 0)
             {

                 company sc = new company
                 {
                     nom = name,
                     adresse = adresse,
                     telephone=tel,
                 };

                 bie.AddTocompanies(sc);
                 bie.SaveChanges();

             }
            var id = from s in bie.companies
                     where s.nom.Equals(name)
                     where s.adresse.Equals(adresse)
                     where s.telephone.Equals(tel)
                     select s.id;
            return id.First();
        }


        //update
    }
}
