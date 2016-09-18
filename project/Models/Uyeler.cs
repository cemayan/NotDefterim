using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Uyeler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string Ad { get; set; }
        public string Soyad{ get;set; }

        public string KullaniciAdi { get; set; }
        public string Email { get; set; }

        public string Sifre { get; set; }
        public string ArkaPlan { get; set; }
        public string Resim { get; set; }

        public DateTime Tarih { get; set; }
        public virtual ICollection<Paylasimlar> Paylasim { get; set; }

        public virtual ICollection<Arkadaslik>  Arkadaslik { get; set; }

    }
}