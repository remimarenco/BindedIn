using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.Security;

namespace Data
{
    public class UserProfile : ProfileBase
    {
        public static UserProfile GetUserProfile(string username)
        {
            return Create(username) as UserProfile;
        }
        public static UserProfile GetUserProfile()
        {
            return Create(Membership.GetUser().UserName) as UserProfile;           
        }

        [SettingsAllowAnonymous(false)]
        public string FirstName
        {
            get { return base["FirstName"] as string; }
            set { base["FirstName"] = value; }
        }

        [SettingsAllowAnonymous(false)]
        public string LastName
        {
            get { return base["LastName"] as string; }
            set { base["LastName"] = value; }
        }

        [SettingsAllowAnonymous(false)]
        public string FavoriteMovie
        {
            get { return base["FavoriteMovie"] as string; }
            set { base["FavoriteMovie"] = value; }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is UserProfile))
            {
                return false;
            }

            UserProfile objProfile = (UserProfile)obj;
            if (this.UserName == objProfile.UserName)
            {
                return true;
            }
            return false;
        }
        
    }
}
