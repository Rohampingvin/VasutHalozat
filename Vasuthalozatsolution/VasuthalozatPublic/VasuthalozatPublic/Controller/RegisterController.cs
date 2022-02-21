using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasuthalozatCommon.Repository;
using VasuthalozatCommon.Model.UserHandling;
using VasuthalozatCommon.RailwayException;

namespace VasuthalozatPublic.Controller
{
    public class RegisterController
    {
        private UserContext userContext = UserContext.Instance;

        public void HandleRegister(string username, string password1, string password2, string email, string name)
        {
            if (password1 != password2)
            {
                throw new VasuthalozatException("A megadott jelszavak nem egyeznek");
            }
            if (userContext.Users.FirstOrDefault(user => user.Email == email || user.UserName == username) != null)
            {
                throw new VasuthalozatException("Ilyen felhasználónévvel vagy email címmel már regisztráltak");
            }
            userContext.Users.Add(new User(
                name, 
                username, 
                email,
                BCrypt.Net.BCrypt.HashPassword(password1, BCrypt.Net.BCrypt.GenerateSalt()), 
                Role.USER));

            userContext.SaveChanges();
        }
    }
}
