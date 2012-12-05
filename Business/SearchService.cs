using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Business
{
    public class SearchService
    {
        public static List<UserProfile> SearchUser(string keyWords)
        {
            UserProfile up;

           bindedinEntities bie = SingletonEntities.Instance;

            //on creait a liste de retour
           List<UserProfile> result = new List<UserProfile>();

            //ondécoupe la recherche en mot
            List<string> listKeyWords = stringToWordArray(keyWords);



            // on recupere les utilisateurs
            var search = from u in bie.aspnet_Users
                         select u;

            //on cherche par le nom
            foreach (aspnet_Users user in search.ToList())
            {
                up = UserProfile.GetUserProfile(user.UserName);

                if (up.FirstName.ToUpper() == keyWords || up.LastName.ToUpper() == keyWords)
                {
                    //on l'ajoute au resultat si il n'est pas deja dans la liste
                    if (!result.Contains(up))
                    {
                        result.Add(up);
                    }
                }
            }


            // on cherche si la chaine contient un nom ou un prenom
            foreach (string word in listKeyWords)
            {
                foreach (aspnet_Users user in search.ToList())
                {
                    up = UserProfile.GetUserProfile(user.UserName);

                    if ((up.FirstName.ToUpper()).Contains(word) || (up.LastName.ToUpper()).Contains(word))
                    {
                        //on l'ajoute au resultat si il n'est pas deja dans la liste
                        if (!result.Contains(up))
                        {
                            result.Add(up);
                        }

                    }
                }
            }
            
            //on recherche par formation
            foreach (string word in listKeyWords)
            {           
                // On récupère les formations en cherchant dans "name" et "description" 
                var searchFormations = from f in bie.formations
                         where  f.name.Contains(word) || f.description.Contains(word)
                         select f;
                if (searchFormations != null)
                {
                    //on parcourt les formations trouvées 
                    foreach (formation f in searchFormations.ToList())
                    {

                        //on parcourt les user_formations et on recupere lesuser asossciés et on les ajoutes 
                        foreach (user_formation uf in f.user_formation)
                        {
                            up = UserProfile.GetUserProfile(uf.aspnet_Users.UserName);

                            //on l'ajoute au resultat si il n'est pas deja dans la liste
                            if (!result.Contains(up))
                            {
                                result.Add(up);
                            } 
                        }
                    }
                }
            }

            //on recherche par compétence
            foreach (string word in listKeyWords)
            {
                // On récupère les compétences en cherchant dans "name" et "description" 
                var searchCompetences = from c in bie.competences
                                       where c.name.Contains(word) || c.description.Contains(word)
                                       select c;
                if (search != null)
                {
                    //on parcourt les compétences trouvées 
                    foreach (competence c in searchCompetences.ToList())
                    {

                        //on parcourt les user_competence et on recupere les user asossciés et on les ajoutes 
                        foreach (user_competence uc in c.user_competence)
                        {
                            up = UserProfile.GetUserProfile(uc.aspnet_Users.UserName);

                            //on l'ajoute au resultat si il n'est pas deja dans la liste
                            if (!result.Contains(up))
                            {
                                result.Add(up);
                            }
                        }
                    }
                }
            }

            return result;

        }


        //methode qui convertit un string en list utilisé pour parcourir tous les mots de recherche et les different mots des experience et des formations 
        private static List<string> stringToWordArray(string s)
        {
            List<string> words = new List<string>();
            string word;
            s = s.ToUpper();
            s = s.Trim(',', '.', '"', '-', ' ', ':', ';', '\n', '!', '?');
            while (s.Length > 0)
            {
                if (s.Contains(' '))
                {
                    word = s.Substring(0, s.IndexOf(" "));
                    s = s.Substring(s.IndexOf(" ") + 1);
                    s = s.Trim();
                }
                else
                {
                    word = s;
                    s = "";
                }
                word = word.Trim(',', '.', '"', '-', ' ', ':', ';', '\n', '!', '?');
                if (word.Length > 0)
                    words.Add(word);
                else
                    return words;

            }
            return words;
        }

        //methode qui verifie si une liste passé en paramtre contient le string passé en parametre
        private static Boolean ContainsInStringList(List<string> l, string s)
        {
            foreach (string item in l)
            {
                Console.WriteLine( "item "+item+" string "+s);
                if (item == s)
                {
                    return true;
                }
            }
            return false;
        }


    }


}