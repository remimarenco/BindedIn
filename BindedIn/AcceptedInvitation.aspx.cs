using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BindedIn
{
    public partial class AcceptedInvitation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String idAskedUser = Request.Params["id_asked"];

            String idAskingUser = Request.Params["id_asking"];


        }
    }
}