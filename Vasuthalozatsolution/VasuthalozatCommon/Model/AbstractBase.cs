using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VasuthalozatCommon.Model
{
    public abstract class AbstractBase
    {
        public long Id { get; set; }
    }
}
