using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using System.Globalization;

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

        public static void InsertNewFormation(String nom,
            String description, String dateDebut, String dateFin, String etablissement)
        {
            bindedinEntities bie = SingletonEntities.Instance;          

            formation ord = new formation
            {
                name = nom,
                description = description,
                beginning_date = DateTime.Parse(dateDebut,CultureInfo.CreateSpecificCulture("en-US")),
                end_date =  DateTime.Parse(dateFin,CultureInfo.CreateSpecificCulture("en-US")),
                school= Business.SchoolsService.InsertSchool(etablissement, ""),            
               
            };            
            bie.AddToformations(ord);
            bie.SaveChanges();
        }

    }
}
