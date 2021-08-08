using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Servera_puse.Entities
{
    public class File
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Descryption { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public string Link { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public Extension Extension { get;  set; }
    }
}