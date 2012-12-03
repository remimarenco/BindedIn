using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
using System.Web.Security;

namespace BindedIn
{
    public partial class _Default : System.Web.UI.Page
    {

        public UserProfile Profile { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Write to a user profile from a textbox value
            Profile = UserProfile.GetUserProfile(User.Identity.Name);
           
            if (Profile.FavoriteMovie == "")
            {
                Profile.FavoriteMovie = "Potatoe";
                Profile.Save();                            
            }

            //var userId = (Guid)(Membership.GetUser(User.Identity.Name, false).ProviderUserKey);
            //ceci est un example de la reatribution d'un user id pour le data source. Très utile pour lié un user a tout le reste. !!!!
            //ObjectDataSourceFormation.SelectParameters["userId"].DefaultValue = "2";
        }
    }
}
