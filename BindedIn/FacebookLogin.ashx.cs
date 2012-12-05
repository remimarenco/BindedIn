using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Facebook;
using System.Web.Security;
using Data;

namespace BindedIn
{
    /// <summary>
    /// Description résumée de FacebookLogin
    /// </summary>
    public class FacebookLogin : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            MembershipUser user;
            var accessToken = context.Request["accessToken"];            
            var client = new FacebookClient(accessToken);
            dynamic result = client.Get("me", new { fields = "first_name,last_name,email" });
            string last_name = result.last_name;
            string first_name = result.first_name;
            string email = result.email;

            if (Membership.FindUsersByEmail(email).Count == 0)
            {
                user = Membership.CreateUser(email, Membership.GeneratePassword(20, 0), email);
                UserProfile userProfile = UserProfile.GetUserProfile(user.UserName);
                userProfile.LastName = last_name;
                userProfile.FirstName = first_name;
                userProfile.Save();
            }
            else 
                user = Membership.GetUser(email);

            //Membership.ValidateUser(user.UserName, user.GetPassword());
            FormsAuthentication.SetAuthCookie(email, true);
            context.Response.Redirect("/Default.aspx");
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}