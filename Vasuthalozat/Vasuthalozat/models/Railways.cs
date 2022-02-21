using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vasuthalozat.models
{
    [Table(name:"Railways")]
    class Railways
    {
        
        public int distance { get; set; }
         [Required]
         [MaxLength(100)]
        public Cities from { get; set; }
        [Required]
        [MaxLength(100)]
        public Cities to { get; set; }
    }
}
