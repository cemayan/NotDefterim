﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class Arkadaslik
    {
        public int ID { get; set; }


        public Guid Uyeler_ID { get; set; }

        [ForeignKey("Uyeler")]
        public Guid Uyeler2_ID { get; set; }

        public bool Durum { get; set; }

        public DateTime Tarih { get; set; }

        public virtual Uyeler Uyeler { get; set; }
    }
}