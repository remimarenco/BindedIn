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
    public partial class Relations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userId = (Guid)(Membership.GetUser(User.Identity.Name, false).ProviderUserKey);
            //ceci est un example de la reatribution d'un user id pour le data source. Très utile pour lié un user a tout le reste. !!!!
            ObjectDataSourceRelation.SelectParameters["userId"].DefaultValue = userId.ToString();
            ObjectDataSourceFarFromOneRelation.SelectParameters["userId"].DefaultValue = userId.ToString();
            
        }
    }
}