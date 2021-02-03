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
        
        [Required, MaxLength(40)]
        public string Naziv { get; set; }

        [Required]
        [Display(Name ="Inventurni broj")]
        public int InventurniBroj { get; set; }

        [Display(Name ="Datum nabave"),DisplayFormat(DataFormatString ="{0:dd.MM.yyy}")]
        public DateTime DatumNabave { get; set; }

        [Display(Name ="Nabavna cijena")]
        public decimal NabavnaCijena { get; set; }

        public Grupa Grupa { get; set; }

        public int GrupaId { get; set; }

    }
}
