using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasuthalozatCommon.Model.UserHandling;

namespace VasuthalozatCommon.Auth
{
    public interface IAuthenticator
    {
        public delegate void LogoutDelegate();

        public event LogoutDelegate LogoutEvent;

        public User Authenticate(string username, string password);

        public void Logout();
    }
}
