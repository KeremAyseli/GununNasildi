using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GununNasıldı.Models.Entity;
using Newtonsoft.Json;
using System.IO;
namespace GununNasıldı.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        gununnasildiEntities4 veritabani = new gununnasildiEntities4();
        public ActionResult Yazı()
        {
            kisiler kisi = new kisiler();
            string yazıAdresi = veritabani.yazilar.Where(yazıId => yazıId.yaziId == kisi.YaziId.ToString()).First().yaziIcerikAdres.ToString();
            StreamReader okuma = new StreamReader(yazıAdresi);
            yaziTipi yazılar = JsonConvert.DeserializeObject<yaziTipi>(okuma.ReadToEnd());

            return View();
        }
        [HttpGet]
        public ActionResult kayıtOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult kayıtOl(kisiler kisi)
        {
            veritabani.kisiler.Add(kisi);
            veritabani.SaveChanges();
            return View();
        }
        kontrol kontrol = new kontrol();
        
         [HttpPost]
        public ActionResult yazıYaz(yaziTipi yazı)
        {
           
            string yol = Server.MapPath("~/yazilar/"+kontrol.dosyaİsimOlusturma(@"~\yazilar\"));
            System.IO.File.WriteAllText(yol, JsonConvert.SerializeObject(yazı));
          
            return View();
        }
        [HttpGet]
        public ActionResult yazıYaz()
        {
            ViewBag.kullanıcı = HttpContext.Request.Cookies["ID"].Value;
            return View();
        }
        public string yolOluştur()
        {
            Random rastgele = new Random();
            string dosyaİsmi = "";
            for(int i = 0; i < 15; i++)
            {
              dosyaİsmi+= ((char)rastgele.Next(10000)).ToString();
            }
            return dosyaİsmi;
        }
       
        [HttpPost]
        public ActionResult girisYap(kisiler kisi)
        {
            if (kisi.kisiIsim != null && kisi.sifre != null)
            {
                var x = veritabani.kisiler.First(giris => giris.kisiIsim == kisi.kisiIsim && giris.sifre == kisi.sifre);
                if (x!=null)
                {
                    HttpCookie kullanıcıBilgileri = new HttpCookie("ID", x.kisiId.ToString());
                    HttpContext.Response.Cookies.Add(kullanıcıBilgileri);
                } 
            }
            return View();
        }
        [HttpGet]
        public ActionResult girisyap()
        {
            return View();
        }
        public ActionResult profil()
        {
            return View();
        }
       
       
    }
}