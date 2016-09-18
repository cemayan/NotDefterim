using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project.Models.Signin
{
    public class Kayit
    {


        [Required(ErrorMessage ="Lütfen Adı boş bırakmayınız")]
        public string Ad { get; set; }

        [Required(ErrorMessage ="Lütfen Soyadı boş bırakmayınız")]
        public string Soyad { get; set; }

        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Boş Bırakmayınız")]
        [Display(Name ="Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage="Lütfen emaili boş bırakmayınız")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Lütfen şifre giriniz")]
        public string Sifre { get; set; }
        public string SifreT { get; set; }
        public string ArkaPlan { get; set; }
        public string Resim { get; set; }
    }
}