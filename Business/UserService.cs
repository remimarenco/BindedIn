using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;


namespace Business
{
    public class UserService
    {

        public static List<aspnet_Users> GetUtilisateurs()
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var users = from c in bie.aspnet_Users
                        select c;
            return users.ToList();
        }

        public static List<aspnet_Users> GetUtilisateurs(Guid id)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var users = from c in bie.aspnet_Users
                        where c.UserId.Equals(id)
                        select c;
            return users.ToList();
        }

        public static aspnet_Users GetUtilisateurById(Guid id)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            var users = from c in bie.aspnet_Users
                        where c.UserId.Equals(id)
                        select c;

            aspnet_Users u = new aspnet_Users();

            foreach (aspnet_Users userItem in users.ToList())
            {
                u = userItem;
            }
            return u;
        }

    }
}
