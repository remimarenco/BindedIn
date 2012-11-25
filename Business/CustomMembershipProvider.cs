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
    }
}
