using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OsnovnaSredstva.Models
{
    public class OsnSredstvo
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Naziv { get; set; }

        [Required]
        
        public int InventurniBroj { get; set; }

        public DateTime DatumNabave { get; set; }

        public double Kolicina { get; set; }
        public decimal NabavnaCijena { get; set; }

        public Grupa Grupa { get; set; }

        public int GrupaId { get; set; }

    }
}
