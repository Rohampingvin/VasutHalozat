using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VasuthalozatCommon.Model
{
    public class Railway : AbstractBase
    {
        public String FromCity { get; set; }

        public String ToCity { get; set; }

        public int Distance { get; set; }
    }
}
