using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Business
{
    public class SearchService
    {
        public static List<Data.users> SearchUser(string keyWords)
        {


            bindedinEntities bie = SingletonEntities.Instance;

            //on creait a liste de retour
            List<users> result = new List<users>();

            //ondécoupe la recherche en mot
            List<string> listKeyWords = stringToWordArray(keyWords);


            /************************************************************************************
             * Recherche par le nom
             * 
             ************************************************************************************/
            // on cherche si la chaine correspond exactement a nom prenom ou prenom nom
            var search = from u in bie.users
                         where (u.firstname + " " + u.lastname == keyWords) || (u.lastname + " " + u.firstname == keyWords)
                         select u;
            foreach (users user in search.ToList())
            {
                //on l'ajoute au resultat si il n'est pas deja dans la liste
                if (!result.Contains(user))
                {
                    result.Add(user);
                }
            }




            // on cherche si la chaine contient un nom ou un prenom
            foreach (string word in listKeyWords)
            {
                // On récupère les utilisateurs
                search = from u in bie.users
                         where u.firstname.Contains(word) || u.lastname.Contains(word)
                         select u;
                foreach (users user in search.ToList())
                {
                    //on l'ajoute au resultat si il n'est pas deja dans la liste
                    if (!result.Contains(user))
                    {
                        result.Add(user);
                    }
                }

            }

            /************************************************************************************
             * Recherche par les formations
             * 
             ************************************************************************************/
            foreach (string word in listKeyWords)
            {
                
                // On récupère les formations en cherchant dans "name" et "description" 
                var searchFormations = from f in bie.formations
                         where  f.name.Contains(word) || f.description.Contains(word)
                         select f;

                if (search != null)
                {
                    //on parcourt les formations trouvées 
                    foreach (formations f in searchFormations.ToList())
                    {
                        //on parcourt les user_formations et on recupere lesuser asossciés et on les ajoutes 
                        foreach (user_formation uf in f.user_formation)
                        {
                            //on recupere l'utilisateur corespondant a l'user_formation
                            foreach (users user in UserService.GetUtilisateurs(uf.user))
                            {
                                //on l'ajoute au resultat si il n'est pas deja dans la liste
                                if (!result.Contains(user))
                                {
                                    result.Add(user);
                                }
                            }
                        }
                    }
                }
            }


            /************************************************************************************
             * Recherche par les competences
             * 
             ************************************************************************************/
            foreach (string word in listKeyWords)
            {
                
                // On récupère les competences en cherchant dans "name" et "description" 
                var searchCompetences = from c in bie.competences
                         where  c.name.Contains(word) || c.description.Contains(word)
                         select c;

                if (search != null)
                {
                    //on parcourt les compétences trouvées 
                    foreach (competences c in searchCompetences.ToList())
                    {
                        //on parcourt les user_competence et on recupere les user asossciés et on les ajoutes 
                        foreach (user_competence uc in c.user_competence)
                        {
                            //on recupere l'utilisateur corespondant a l'user_competence
                            foreach (users user in UserService.GetUtilisateurs(uc.user))
                            {
                                //on l'ajoute au resultat si il n'est pas deja dans la liste
                                if (!result.Contains(user))
                                {
                                    result.Add(user);
                                }
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