using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;

namespace BindedIn
{
    public partial class Relations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserProfile profile = UserProfile.GetUserProfile(User.Identity.Name);
            //ceci est un example de la reatribution d'un user id pour le data source. Très utile pour lié un user a tout le reste. !!!!
            //ObjectDataSourceRelation.SelectParameters["userId"].DefaultValue = profile.; 
        }

        
    }
}