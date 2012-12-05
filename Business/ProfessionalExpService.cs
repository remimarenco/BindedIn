using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using System.Globalization;
using System.Data;

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

        public static List<professional_experience> GetProferssionalExp(Guid userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var retour = from ue in bie.user_experienceprofessional from p in bie.professional_experience
                                 where ue.user.Equals(userId)
                                 where ue.experience_professional.Equals(p.id)
                                 select p;
        
            return retour.ToList();
        }

        public static void InsertNewProfessionalExp(String name, String description, String dateDebut, String dateFin, 
            String companyName, String companyAdresse,String companyTel,Guid userId)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var existingProfExp = from pe in bie.professional_experience
                                  from c in bie.companies
                                  where pe.name.Equals(name)
                                  where pe.company.Equals(c.id)
                                  where c.nom.Equals(companyName)
                                  select pe;

            if (existingProfExp.Count() == 0)
            {
                professional_experience profExp = new professional_experience
                {
                    name=name,
                    description=description,
                    company=Business.CompanyService.InsertCompany(companyName,companyAdresse,companyTel)
                };

                bie.professional_experience.AddObject(profExp);
                bie.SaveChanges();
            }
            var idExpPro = from pe in bie.professional_experience from c in bie.companies
                                  where pe.name.Equals(name)
                                  where pe.company.Equals(c.id)
                                  where c.nom.Equals(companyName)
                                  select pe.id;

               

            user_experienceprofessional uf = new user_experienceprofessional
            {
                user = userId,
                experience_professional = idExpPro.First(),
                beginning_date = DateTime.Parse(dateDebut, CultureInfo.CreateSpecificCulture("en-US")),
                end_date = DateTime.Parse(dateFin, CultureInfo.CreateSpecificCulture("en-US")),
            };
            bie.user_experienceprofessional.AddObject(uf);             
            bie.SaveChanges();
            
        }

    }
}
