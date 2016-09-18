using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models.Create
{
    public class Ekle
    {
        public string Paylasim { get; set; }

        public string PaylasimResim { get; set; }

        public string PaylasimVideo { get; set; }

        public int Begen { get; set; }

        public int Favori { get; set; }

        public int PaylasimTur_ID { get; set; }

        public Guid Uyeler_ID { get; set; }

        public DateTime Tarih { get; set; }
    }
}