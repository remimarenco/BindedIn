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
    public partial class AcceptedInvitation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String idAskedUser = Request.Params["id_asked"];
            
            UserProfile asked_user = UserProfile.GetUserProfile(Membership.GetUser(Guid.Parse(idAskedUser)).UserName);

            String idAskingUser = Request.Params["id_asking"];

            UserProfile asking_user = UserProfile.GetUserProfile(Membership.GetUser(Guid.Parse(idAskingUser)).UserName);

            linkUserAsking.PostBackUrl = String.Format("Profil.aspx?id={0}", Membership.GetUser(Guid.Parse(idAskingUser)).UserName);
            linkUserAsking.Text = String.Format("{0} {1}", asking_user.FirstName, asking_user.LastName);


        }
    }
}