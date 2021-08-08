using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Servera_puse.Entities
{
    public class Extension
    {
        [Key]
        public string Extension_name { get; set; }
    }
}
