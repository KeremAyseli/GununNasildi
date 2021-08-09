using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GununNasıldı.Models.Entity;
using System.Diagnostics;
using System.IO;
namespace GununNasıldı.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanıcı
        public ActionResult Index()
        {
            return View();
        }
        gununnasildiEntities4 veritabani = new gununnasildiEntities4();
     
        /// <summary>
        /// Giris yapmayı sağlayan metot,veri tabanını kontrol ederek bilgiler doğrulanırsa siteye giriş yapmayı sağlar.Giriş yaptıkran sonra cookie oluşturur.
        /// </summary>
        /// <param name="isim"></param>
        /// <param name="sifre"></param>
        /// <returns></returns>
        [HttpPost]
        public bool giris(string isim,string sifre)
        {
            if (isim != null && sifre != null)
            {
                try
                {
                    kisiler kisi = veritabani.kisiler.First(giris => giris.kisiIsim == isim && giris.sifre == sifre);
                    if (kisi != null)
                    {
                        HttpCookie kullanıcıBilgileri = new HttpCookie("ID", kisi.kisiId.ToString());
                        HttpCookie kullanıcıİsim = new HttpCookie("Isim", kisi.kisiIsim);
                        HttpCookie kullanıcıSoyisim = new HttpCookie("Soyisim", kisi.kisiSoyisim);
                        HttpCookie kullanıcıResimAdresi = new HttpCookie("ResimAdres", kisi.kisiResimAdres);
                        HttpContext.Response.Cookies.Add(kullanıcıBilgileri);
                        HttpContext.Response.Cookies.Add(kullanıcıİsim);
                        HttpContext.Response.Cookies.Add(kullanıcıSoyisim);
                        HttpContext.Response.Cookies.Add(kullanıcıResimAdresi);
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
            return false;
        }
        [HttpGet]
        public ActionResult girisYap()
        {
            return View();
        }
        /// <summary>
        /// Profil sayfasına girildikten sonra gelen ID bilgisine göre profil sayfasını düzenleyen metot.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult profil(int ID)
        {
            var sorgu = veritabani.kisiler.Where(kisiBilgiler => kisiBilgiler.kisiId == ID).First();
            kisiTipi kisi = new kisiTipi();
            kisi.kisiId = sorgu.kisiId;
            kisi.kisiIsim = sorgu.kisiIsim;
            kisi.kisiSoyisim = sorgu.kisiSoyisim;
            kisi.kisiResimAdres = sorgu.kisiResimAdres;
          
            return View("profil",kisi);
        }
        kontrol rastgeleAdresVeId = new kontrol();
        /// <summary>
        /// Gelen bilgilerden isim eğer veritabanında yoksa,yeni kullanıcıyı veri tabanına eklemeyi sağlar.
        /// </summary>
        /// <param name="isim"></param>
        /// <param name="soyisim"></param>
        /// <param name="Eposta"></param>
        /// <param name="resim"></param>
        /// <param name="sifre"></param>
        /// <returns></returns>
        [HttpPost]
        public bool kayitOl(string isim,string soyisim,string Eposta,HttpPostedFileBase resim,string sifre)
        {

            try
            {
                veritabani.kisiler.First(kisiKontrol => kisiKontrol.kisiIsim == isim);
                return false;
            }
            catch
            {
                var resimAdres = Server.MapPath("~/resimler/") + rastgeleAdresVeId.rastgeleID() + ".png";
                resim.SaveAs(resimAdres);
                kisiler kisi = new kisiler();
                kisi.kisiIsim = isim;
                kisi.kisiSoyisim = soyisim;
                kisi.kisiEposta = Eposta;
                kisi.kisiResimAdres = resimAdres.Split('\\')[5];
                kisi.sifre = sifre;
                veritabani.kisiler.Add(kisi);
                veritabani.SaveChanges();
                return true;
                
            }
        }
        [HttpGet]
        public ActionResult kayitOl()
        {
            return View();
        }
    }
}