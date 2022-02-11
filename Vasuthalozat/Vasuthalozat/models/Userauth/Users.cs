using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasuthalozat.models.Userauth;
using static Vasuthalozat.models.Userauth.Role;

namespace Vasuthalozat.models.Userauth
{
    [Table("USERS")]
    class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }

        public Users(string name, string userName, string email, string password, Roles role)
        {
            Name = name;
            UserName = userName;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
