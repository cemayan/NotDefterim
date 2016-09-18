using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project.Models.Login
{
    public class Giris
    {

        public string Email { get; set; }
        public string Sifre { get; set; }
    }
}