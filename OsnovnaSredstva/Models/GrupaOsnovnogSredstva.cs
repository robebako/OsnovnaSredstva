﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OsnovnaSredstva.Models
{
    public class Grupa
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(40)]
        [Display(Name ="Naziv Grupe")]
        public string NazivGrupe { get; set; }
    }
}