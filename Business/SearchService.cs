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
                         where u.firstname == word || u.lastname == word
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

            return result;

        }

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

    }


}