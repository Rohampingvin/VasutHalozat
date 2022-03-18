using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasuthalozatCommon.Auth;
using VasuthalozatCommon.Repository;
using VasuthalozatCommon.Model;

namespace VasuthalozatPublic.Controller
{
    public class RailwayPickerController
    {
        private IAuthenticator authenticator = UserAuthenticator.Instance;
        private VasuthalozatContext Vasuthalozat = VasuthalozatContext.Instance;

        public void SubscibeToLogout(IAuthenticator.LogoutDelegate logoutDelegate)
        {
            authenticator.LogoutEvent += logoutDelegate;
        }

        public void UnsubscribeFromLogout(IAuthenticator.LogoutDelegate logoutDelegate)
        {
            authenticator.LogoutEvent -= logoutDelegate;
        }

        public void Logout()
        {
            authenticator.Logout();
        }
    }
}
