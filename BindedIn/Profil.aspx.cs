using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BindedIn
{
    public partial class Profil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //editSkills.Visible = false;
            //editExp.Visible = false;
            //editFormation.Visible = false;
       
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            if(sender.Equals(ButtonEditSkills))
                editSkills.Visible = true;
            else if (sender.Equals(ButtonEditFormation))
                editFormation.Visible = true;
            else if (sender.Equals(ButtonEditExp))
                editExp.Visible = true;
        }
    }
}