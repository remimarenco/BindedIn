using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Business
{
    class CustomMembershipProvider : SqlMembershipProvider
    {
        public override bool ValidateUser(string email, string password)
        {
            return base.ValidateUser(Membership.GetUserNameByEmail(email), password);
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            return base.CreateUser(username, password, username, passwordQuestion, passwordAnswer, isApproved, providerUserKey, out status);
        }
    }
}
