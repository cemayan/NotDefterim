using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.Models.Login;
using project.Yetki;
using System.Web.Security;
using System.Dynamic;
using project.Models.Create;
using project.Models.Paylasim;
using project.Models.Signin;

namespace project.Controllers
{
    public class AnasayfaController : Controller
    {
        readonly static IProjectRepository projectRespository = new PaylasimlarRepository();

        [UserAuthorize]
        public ActionResult Index()
        {

            string name = User.Identity.Name;
            Guid id = new Guid(name);
            ViewBag.User = projectRespository.Uye(id);
            dynamic veri = new ExpandoObject();
            veri.Bilgiler = projectRespository.Uye(id);
            veri.ArkadaslarT = projectRespository.Kimi(id);
            veri.TakipeSayi = projectRespository.TkpeSayi(id);
            veri.TkpcSayi = projectRespository.TkpSayi(id);
            veri.GondrSayi = projectRespository.GonSayi(id);
            veri.BegenSayi = projectRespository.BegenSayi(id);
            veri.Gundem = projectRespository.AllG().OrderByDescending(x => x.Sayac);
            return View(veri);
   
        }

        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Signin()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signin(Kayit uye)
        {
            if(uye.Sifre == uye.SifreT)
            {
                if (ModelState.IsValid)
                {
                    projectRespository.AddU(uye);
                    ViewBag.Basarili = 1;
                }
            }
            else
            {
                ModelState.AddModelError("", "Şifrenizi Kontrol Ediniz");
            }      
  
            return View(uye);
        }

        public ActionResult Logout()
        {


            FormsAuthentication.SignOut();        
            return RedirectToAction("Login","Anasayfa");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Giris uyeler)
        {
            var abc = projectRespository.Login(uyeler);

            if (abc != null)
            {

                FormsAuthentication.SetAuthCookie(abc.ID.ToString(), true);
                return RedirectToAction("Index", "Anasayfa");

            }
            else
            {
                ModelState.AddModelError("", "Email veya şifre hatalı!");
            }

            return View();
        }


        public JsonResult All()
        {
            try
            {
                string name = User.Identity.Name;
                Guid id = new Guid(name);


                var abc = projectRespository.Arkadaslar(id);
                var rr = projectRespository.BListe(id);

                List<pylsm> collection = new List<pylsm>();
                List<pylsm> collection2 = new List<pylsm>();

                var ee = rr.All(x =>
                {
                    collection2.AddRange(x.Paylasim.Select(y => new pylsm { Paylasim = y.Paylasim, Begen = y.Begen, Favori = y.Favori, PaylasimTur = y.PaylasimTur,UyeID=y.Uyeler_ID,UyeAd = y.Uyeler.Ad, KullaniciAdi = y.Uyeler.KullaniciAdi, UyeSoyad = y.Uyeler.Soyad, UyeResim = y.Uyeler.Resim, Tarih = y.Tarih }));
                    return true;
                });

                var dd = abc.All(x =>
                {
                    collection.AddRange(x.Paylasim.Select(y => new pylsm { Paylasim = y.Paylasim, Begen = y.Begen, Favori = y.Favori, PaylasimTur = y.PaylasimTur, UyeID = y.Uyeler_ID, UyeAd = y.Uyeler.Ad, KullaniciAdi = y.Uyeler.KullaniciAdi, UyeSoyad = y.Uyeler.Soyad, UyeResim = y.Uyeler.Resim, Tarih = y.Tarih }));
                    return true;

                });

                return Json(collection.Union(collection2).OrderByDescending(y => y.Tarih), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("Hata Oluştu.", JsonRequestBehavior.AllowGet);
            }
         
           
        }


        public JsonResult Add(Ekle data)
        {
            if (ModelState.IsValid)
            {
                projectRespository.Add(data);
            }
            else
            {
                return Json("Bir hata oluştu");
            }
       
            return Json("");
        }


        [HttpPost]
        public JsonResult Takip(Guid Uyeid,Guid Uyeid2)
        {
            if (ModelState.IsValid)
            {
                projectRespository.AddT(Uyeid,Uyeid2);
            }
            else
            {
                return Json("Bir hata oluştu");
            }

            return Json("");
        }



        [HttpPost]
        public JsonResult TakipKes(Guid Uyeid, Guid Uyeid2)
        {
            if (ModelState.IsValid)
            {
                projectRespository.RemoveT(Uyeid, Uyeid2);
            }
            else
            {
                return Json("Bir hata oluştu");
            }

            return Json("");
        }

        public JsonResult Uyeler(string term)
        {
            try
            {
                var abc = projectRespository.AllU().Where(x => x.Ad.ToLower().Contains(term) || x.Soyad.ToLower().Contains(term) || x.Email.ToLower().Contains(term) || x.KullaniciAdi.ToLower().Contains(term)).Take(5).Select(x => new { label = x.Ad + " " + x.Soyad, label2 = x.ID, icon = x.Resim });
                return Json(abc, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("aa", JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult Gundem(string term)
        {
            try
            {
                var abc = projectRespository.AllG().Where(x => x.Baslik.ToLower().Contains(term)).Take(5).Select(x => new { label = x.Baslik, label2 = x.ID });
                return Json(abc, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("aa", JsonRequestBehavior.AllowGet);
            }

        }




    }
}