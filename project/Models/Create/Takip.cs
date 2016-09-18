using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models.Create
{
    public class Takip
    {

        public Guid Uyeler_ID { get; set; }

        public Guid Uyeler2_ID { get; set; }

        public bool Durum { get; set; }

        public DateTime Tarih { get; set; }
    }
}