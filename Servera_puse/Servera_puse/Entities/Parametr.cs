﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Servera_puse.Entities
{
    public class Parametr
    {
        [Key]
        public string Name { get;  set; }
        [Required]
        public int Value { get; set; }
    }
}