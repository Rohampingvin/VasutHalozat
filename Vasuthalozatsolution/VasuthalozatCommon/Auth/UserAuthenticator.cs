using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasuthalozatCommon.RailwayException;
using VasuthalozatCommon.Repository;
using VasuthalozatCommon.Model.UserHandling;

namespace VasuthalozatCommon.Auth
{
    public sealed class UserAuthenticator : IAuthenticator
    {
        public event IAuthenticator.LogoutDelegate LogoutEvent;

        private static UserContext userContext = UserContext.Instance;
        public User? LoggedInUser { get; set; }

        private static UserAuthenticator? userAuthenticator;

        public static UserAuthenticator Instance
        {
            get
            {
                if (userAuthenticator == null)
                {
                    userAuthenticator = new UserAuthenticator();
                }
                return userAuthenticator;
            }
        }

        private UserAuthenticator() 
        {
        }

        public User Authenticate(string username, string password)
        {
            User? user = userContext.Users.FirstOrDefault(user => user.UserName == username);
            if (user == null)
            {
                throw new VasuthalozatException("Hibás felhasználónév");
            }
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new VasuthalozatException("Hibás jelszó");
            }
            LoggedInUser = user;
            return user;
        }

        public void Logout()
        {
            LoggedInUser = null;
            LogoutEvent?.Invoke();
        }
    }
}
