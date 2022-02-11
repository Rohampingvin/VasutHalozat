using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vasuthalozat.UserExecption
{
    public class Exec : Exception
    {
        public Exec(string message) : base(message)
        {

        }
    }
}
