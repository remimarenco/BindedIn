using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Data;

namespace BindedIn.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, true /* createPersistentCookie */);
            
            UserProfile newUser = UserProfile.GetUserProfile(RegisterUser.UserName);
            newUser.LastName = 
                ((TextBox)RegisterUser.WizardSteps[0].FindControl("CreateUserStepContainer").FindControl("LastName")).Text.Trim();
            newUser.FirstName = 
                ((TextBox)RegisterUser.WizardSteps[0].FindControl("CreateUserStepContainer").FindControl("FirstName")).Text.Trim();
            newUser.Save();           

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }
    }
}