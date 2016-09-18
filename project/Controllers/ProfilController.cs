using project.Models;
using project.Models.Paylasim;
using project.Yetki;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class ProfilController : Controller
    {
        readonly static IProjectRepository projectRespository = new PaylasimlarRepository();

        [UserAuthorize]
        public ActionResult Kullanici(Guid id)
        {
            dynamic veri = new ExpandoObject();
            string name = User.Identity.Name;
            Guid aa = new Guid(name);

                veri.Bilgiler = projectRespository.Uye(aa);
                veri.ArkadaslarT = projectRespository.ArkadasTakip(aa);
                veri.Arkadaslar = projectRespository.Arkadaslar(aa);


                veri.Bilgiler2 = projectRespository.Uye(id);
                veri.ArkadaslarT2 = projectRespository.ArkadasTakip(id);
                veri.Arkadaslar2 = projectRespository.Arkadaslar(id);


            veri.UyeID = id;

            veri.TakipeSayi = projectRespository.TkpeSayi(id);
            veri.TkpcSayi = projectRespository.TkpSayi(id);
            veri.GondrSayi = projectRespository.GonSayi(id);
            veri.BegenSayi = projectRespository.BegenSayi(id);
            return View(veri);
        }

        public JsonResult AllK(Guid id)
        {
            try
            {

           
                var rr = projectRespository.AllK(id).Select(y => new pylsm { Paylasim = y.Paylasim, Begen = y.Begen, Favori = y.Favori, PaylasimTur = y.PaylasimTur, UyeAd = y.Uyeler.Ad, KullaniciAdi = y.Uyeler.KullaniciAdi, UyeSoyad = y.Uyeler.Soyad, UyeResim = y.Uyeler.Resim, Tarih = y.Tarih });

                return Json(rr.OrderByDescending(y => y.Tarih), JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(e.ToString(), JsonRequestBehavior.AllowGet);
            }


        }

        public JsonResult ArkadasO(Guid id,Guid id2)
        {
            var abc = projectRespository.ArkadaslarO(id,id2);
            return Json(abc,JsonRequestBehavior.AllowGet);
        }


        public ActionResult Duzenle()
        {
            string name = User.Identity.Name;
            Guid aa = new Guid(name);


            return View();

        }


    }
}