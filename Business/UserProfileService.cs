using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Business
{
    public class UserProfileService
    {
        public static List<UserProfile> GetUtilisateurs()
        {
            bindedinEntities bie = SingletonEntities.Instance;
            List<UserProfile> usersList = new List<UserProfile>();

            var users = from c in bie.aspnet_Users
                        select c;
            foreach( aspnet_Users u in users.ToList() ) {
                usersList.Add(UserProfile.GetUserProfile(u.UserName));
            }
            return usersList;
        }

        public static List<UserProfile> GetUtilisateurs(Guid id)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            List<UserProfile> usersList = new List<UserProfile>();

            var users = from c in bie.aspnet_Users
                        where c.UserId.Equals(id)
                        select c;
            foreach (aspnet_Users u in users.ToList())
            {
                usersList.Add(UserProfile.GetUserProfile(u.UserName));
            }
            return usersList;
        }

        public static UserProfile GetUtilisateurById(Guid id)
        {
            bindedinEntities bie = SingletonEntities.Instance;
            UserProfile user = null;

            var users = from c in bie.aspnet_Users
                        where c.UserId.Equals(id)
                        select c;

            foreach (aspnet_Users u in users.ToList())
            {
               user = UserProfile.GetUserProfile(u.UserName);
            }

            return user;
        }
    }
}
