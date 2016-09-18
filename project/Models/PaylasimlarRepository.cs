using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project.Models.Login;
using System.Web.Security;
using System.Web.Mvc;
using project.Models.Create;
using project.Models.Signin;

namespace project.Models
{
    public class PaylasimlarRepository : IProjectRepository
    {
        private ProjectContext db = new ProjectContext();

   
        public IQueryable<Paylasimlar> All()
        {
            return db.Paylasimlar.ToList().AsQueryable();
        }
        public IQueryable<Uyeler> AllU()
        {
            return db.Uyeler.ToList().AsQueryable();
        }

        public IEnumerable<Paylasimlar> Liste()
        {
            return db.Paylasimlar.ToList();
        }
        public void Add(Ekle paylasim)
        {
            Guid id = Guid.Parse(paylasim.Uyeler_ID.ToString());

            Paylasimlar aa = new Paylasimlar()
            {
                Paylasim = paylasim.Paylasim,
                Begen = paylasim.Begen,
                Favori = paylasim.Favori,
                PaylasimResim = paylasim.PaylasimResim,
                PaylasimVideo = paylasim.PaylasimVideo,
                PaylasimTur_ID= paylasim.PaylasimTur_ID,
                Uyeler_ID = id,
                Tarih = DateTime.Now

            };
            db.Paylasimlar.Add(aa);
            db.SaveChanges();
        }

        public Uyeler Login(Giris uyeler)
        {
            return db.Uyeler.Where(x => x.Email == uyeler.Email && x.Sifre == uyeler.Sifre).FirstOrDefault();
        }

        public Uyeler Uye(Guid id)
        {
            return db.Uyeler.FirstOrDefault(x=>x.ID == id);
        }

        public List<Uyeler> ArkadasTakip(Guid id)
        {

            var abc = db.Arkadaslik.Where(x => x.Uyeler_ID == id && x.Durum==false).ToList();
            List<Uyeler> uyeler = new List<Uyeler>();
            foreach (var item in abc)
            {
                if(item.Uyeler2_ID != id)
                    uyeler.Add(item.Uyeler);
            }


            return uyeler;
        }

        public IEnumerable<Uyeler> Arkadaslar(Guid id)
        {
            var abc = db.Arkadaslik.Where(x => x.Uyeler_ID == id && x.Durum == true).Select(x=>x.Uyeler).ToList();
            return abc;
        }

        public IEnumerable<Uyeler> Arkadaslar2(Guid id)
        {
            var abc = db.Arkadaslik.Where(x => x.Uyeler_ID == id && x.Durum == true).Select(x => x.Uyeler).ToList();
            return abc;
        }



        public List<Uyeler> Arkadaslarr(Guid id)
        {
            List<Uyeler> uyeler = new List<Uyeler>();
            foreach (var item in Arkadaslar(id))
            {
                var abc = db.Arkadaslik.Where(x => x.Uyeler_ID == item.ID && x.Durum == true && x.Uyeler2_ID!=id).Select(x => x.Uyeler).ToList();
                uyeler.AddRange(abc);
            }

                foreach (var item in Arkadaslar(id))
                {
                for (int i = 0; i < uyeler.Count; i++)
                {
                    if (uyeler[i].ID == item.ID)
                    {
                        uyeler.Remove(item);
                    }

                }
                 
                }
          

            return uyeler;
        }


        public IEnumerable<Uyeler> BListe(Guid id)
        {
            return db.Uyeler.Where(x=>x.ID == id).ToList();
        }

        public void AddT(Guid Uye1,Guid Uye2)
        {

            var abc = db.Arkadaslik.Where(x => x.Uyeler_ID == Uye1 && x.Uyeler2_ID == Uye2).Select(x => x.Uyeler).FirstOrDefault();
            if (abc != null)
            {

            }
            else
            {

                Arkadaslik a1 = new Arkadaslik()
                {
                    Uyeler_ID = Uye1,
                    Uyeler2_ID = Uye2,
                    Durum = true,
                    Tarih = DateTime.Now
                };

                Arkadaslik a2 = new Arkadaslik()
                {
                    Uyeler_ID = Uye2,
                    Uyeler2_ID = Uye1,
                    Durum = false,
                    Tarih = DateTime.Now
                };

                db.Arkadaslik.Add(a1);
                db.Arkadaslik.Add(a2);
                db.SaveChanges();


            }



        }



        public void RemoveT(Guid Uye1, Guid Uye2)
        {

            var a1 = db.Arkadaslik.Where(x => x.Uyeler_ID == Uye1 && x.Uyeler2_ID == Uye2).FirstOrDefault();
            db.Arkadaslik.Remove(a1);
            db.SaveChanges();
        }




        public void AddU(Kayit uye)
        {
            Uyeler aa = new Uyeler()
            {      
               Ad = uye.Ad,
               Sifre= uye.Sifre,
               Soyad=uye.Soyad,
               KullaniciAdi=uye.KullaniciAdi,
               Email=uye.Email,
               Tarih = DateTime.Now
            };
            db.Uyeler.Add(aa);
            db.SaveChanges();
        }

        public IQueryable<Paylasimlar> AllK(Guid id)
        {
            return db.Paylasimlar.Where(x=>x.Uyeler_ID == id).ToList().AsQueryable();
        }


        public int TkpSayi(Guid id)
        {
            var abc = db.Arkadaslik.Where(x => x.Uyeler_ID == id && x.Uyeler2_ID!=id && x.Durum !=false).Count();

            return abc;
        }

        public int TkpeSayi(Guid id)
        {
            var abc = db.Arkadaslik.Where(x => x.Uyeler_ID != id && x.Uyeler2_ID==id && x.Durum != false).Count();

            return abc;
        }

        public int GonSayi(Guid id)
        {
            var abc = db.Paylasimlar.Where(x => x.Uyeler_ID == id).Count();
            return abc;
        }


        public int BegenSayi(Guid id)
        {
            var abc = db.Paylasimlar.Where(x => x.Uyeler_ID == id && x.Begen !=0).Select(x=>x.Begen).Count();
            return abc;
        }

        public IQueryable<Uyeler> Kimi(Guid id)
        {
            var a2 = Arkadaslarr(id);
            return a2.AsQueryable();
        }

        public bool ArkadaslarO(Guid id,Guid id2)
        {

            try
            {
          
            var abc = db.Arkadaslik.Where(x => x.Uyeler_ID ==id && x.Uyeler2_ID == id2 && x.Durum ==true).Select(x=>x.Uyeler).FirstOrDefault(); 
            if(abc != null)
            {
                return true;
            }
            else
            {
                return false;
            }

            }
            catch
            {
                return false;
            }
        }

        public IQueryable<Gundem> AllG()
        {
            return db.Gundem.ToList().AsQueryable();
        }
    }
}