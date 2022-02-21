using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VasuthalozatCommon.Model
{
    [Table("CITIES")]
    public class City : AbstractBase
    {
       [Column("CITY_NAME")]
       
        public string Name { get; set; }
    }
}
