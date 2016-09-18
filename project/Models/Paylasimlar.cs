using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Paylasimlar
    {
        [Key]
        public int ID { get; set; }
        public string Paylasim { get; set; }

        public string PaylasimResim { get; set; }

        public string PaylasimVideo { get; set; }
        public int Begen { get; set; }

        public int Favori { get; set; }

        [ForeignKey("PaylasimTur")]
        public int PaylasimTur_ID { get; set; }

        [ForeignKey("Uyeler")]
        public Guid Uyeler_ID { get; set; }
        public DateTime Tarih { get; set; }

        public virtual Uyeler Uyeler { get; set; }
        public virtual PaylasimTur PaylasimTur { get; set; }
      

    }
}