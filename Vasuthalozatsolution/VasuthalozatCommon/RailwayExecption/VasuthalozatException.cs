using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VasuthalozatCommon.RailwayException
{
    public class VasuthalozatException : Exception
    {
        public VasuthalozatException(string message) : base(message)
        {
        }
    }
}
