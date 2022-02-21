using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasuthalozat.Repository;
using Vasuthalozat.UserExecption;

namespace Vasuthalozat.models.Userauth
{
    public sealed class  Auth
    {
        public static User? LoggedInUser { get; set; }
        private static UserDbContext userDbContext = UserDbContext.Instance;

        private Auth() { }
        public static User Authenticate(string username, string password)
        {
            User? user = userDbContext.Users.FirstOrDefault(user => user.UserName == username);
            if (user == null)
            {
                throw new Exec("Hibás felhasználónév");
            }
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new Exec("Hibás jelszó");
            }
            LoggedInUser = user;
            return user;
        }
    }
}
