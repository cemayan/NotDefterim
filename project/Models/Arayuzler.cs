using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project.Models.Login;
using project.Models.Create;
using project.Models.Signin;

namespace project.Models
{
    interface IProjectRepository
    {
        IQueryable<Paylasimlar> All();
        IQueryable<Paylasimlar> AllK(Guid id);

        IQueryable<Uyeler> AllU();

        IQueryable<Gundem> AllG();

        IQueryable<Uyeler> Kimi(Guid id);

        List<Uyeler> Arkadaslarr(Guid id);

        Boolean ArkadaslarO(Guid id, Guid id2);

        IEnumerable<Paylasimlar> Liste();

        IEnumerable<Uyeler> BListe(Guid id);
        void Add(Ekle paylasim);

        void AddT(Guid Uye1,Guid Uye2);

        void RemoveT(Guid Uye1, Guid Uye2);

        void AddU(Kayit uye);
        Uyeler Login(Giris uyeler);

        Uyeler Uye(Guid id);

        List<Uyeler> ArkadasTakip(Guid id);

        IEnumerable<Uyeler> Arkadaslar(Guid id);

        int TkpeSayi(Guid id);
        int TkpSayi(Guid id);
        int GonSayi(Guid id);
        int BegenSayi(Guid id);

    }
}
