using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VasuthalozatCommon.Model
{
    [Table("RAILWAYS")]
    public class Railway : AbstractBase
    {
        [Column("FROM_CITY")]
        public String FromCity { get; set; }

        [Column("TO_CITY")]
        public String ToCity { get; set; }

        [Column("DISTANCE")]
        public int Distance { get; set; }
    }
}
