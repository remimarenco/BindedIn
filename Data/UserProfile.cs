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

        public string imageUrl { get; set; }
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
        public string Town
        {
            get { return base["Town"] as string; }
            set { base["Town"] = value; }
        }

        [SettingsAllowAnonymous(false)]
        public string BirthDate
        {
            get { return base["BirthDate"] as string; }
            set { base["BirthDate"] = value; }
        }

        [SettingsAllowAnonymous(false)]
        public string TownZIP
        {
            get { return base["TownZIP"] as string; }
            set { base["TownZIP"] = value; }
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
    }
}
