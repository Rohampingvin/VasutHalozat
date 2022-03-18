using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasuthalozatCommon.Model.UserHandling;
using VasuthalozatCommon.Auth;

namespace VasuthalozatPublic.Controller
{
    public class LoginController
    {
        private IAuthenticator authenticator = UserAuthenticator.Instance;
        public User HandleLoginAttempt(string username, string password)
        {
            return authenticator.Authenticate(username, password);
        }
    }
}
