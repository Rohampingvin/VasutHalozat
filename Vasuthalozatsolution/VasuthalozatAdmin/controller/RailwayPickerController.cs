using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasuthalozatCommon.Auth;
using VasuthalozatCommon.Repository;
using VasuthalozatCommon.Model;


namespace VasuthalozatAdmin.controller
{
    class RailwayPickerController
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

        public List<Cities> GetCities()
        {
            return Vasuthalozat.Cities.ToList(); ;
        }
        public void AddCity(Cities city)
        {
            Vasuthalozat.Cities.Add(city);
            Vasuthalozat.SaveChanges();
        }
    }
}
