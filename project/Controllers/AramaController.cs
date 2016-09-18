using project.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class AramaController : Controller
    {
        readonly static IProjectRepository projectRespository = new PaylasimlarRepository();
        public ActionResult Index(string arama)
        {
            string  name = User.Identity.Name;
            Guid id = new Guid(name);
            dynamic veri = new ExpandoObject();
            veri.Bilgiler = projectRespository.Uye(id);
            veri.Arkadaslar = projectRespository.ArkadasTakip(id);
            return View(veri);
        }
    }
}