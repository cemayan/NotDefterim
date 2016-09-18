using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project.Models;
namespace project.Models.Paylasim
{
    public class pylsm
    {
        public int ID { get; set; }


        public string Paylasim { get; set; }

        public string PaylasimResim { get; set; }

        public string PaylasimVideo { get; set; }
        public int Begen { get; set; }

        public int Favori { get; set; }

        public PaylasimTur PaylasimTur { get; set; }

        public Guid UyeID { get; set; }

        public string UyeAd{ get; set; }

        public string UyeSoyad { get; set; }

        public string UyeResim { get; set; }

        public string KullaniciAdi { get; set; }

        public DateTime Tarih { get; set; }

    }
}