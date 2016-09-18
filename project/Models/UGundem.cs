using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class UGundem
    {
        public int ID { get; set; }

        [ForeignKey("Uyeler")]
        public Guid Uyeler_ID { get; set; }

        [ForeignKey("Gundem")]
        public int Gundem_ID { get; set; }


        public virtual Uyeler Uyeler { get; set; }
        public virtual Gundem Gundem { get; set; }
    }
}