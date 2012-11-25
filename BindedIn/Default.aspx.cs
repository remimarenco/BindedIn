using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;

namespace BindedIn
{
    public partial class _Default : System.Web.UI.Page
    {
        UserProfile profile; 

        protected void Page_Load(object sender, EventArgs e)
        {
            //Write to a user profile from a textbox value
            profile = UserProfile.GetUserProfile(User.Identity.Name);
            if (profile.FavoriteMovie == "")
            {
                profile.FavoriteMovie = "Potatoe";
                profile.Save();
            }
            TextBox1.Text = profile.FavoriteMovie;
        }

        protected void ButUpdate_Click(object sender, EventArgs e)
        {
            // doesn't work ?
            profile.FavoriteMovie = TextBox1.Text;
            profile.Save();
        }
    }
}
