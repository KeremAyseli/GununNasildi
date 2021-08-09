using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GununNasıldı.Models.Entity;
using Newtonsoft.Json;
using System.Diagnostics;

namespace GununNasıldı.Controllers
{
    public class yazilarController : Controller
    {
        kontrol kontrol = new kontrol();
        yaziTipi yazi = new yaziTipi();
        // GET: yazilar
        public ActionResult Index()
        {
            return View();
        }
        gununnasildiEntities4 veritabani = new gununnasildiEntities4();
        /// <summary>
        /// Gelen yazı bilgilerine göre yazıyı kaydetmeye yarayan metot.Hem json dosya hem de veri tabanına kayıt işlemlerini yapıyor.
        /// </summary>
        /// <param name="yazı"></param>
        /// <returns></returns>
        public bool yaziKaydet(yaziTipi yazı)
        {
            yazilar VeriTabaniyazi = new yazilar();
            try
            {
                string adres =  kontrol.dosyaİsimOlusturma(@"~\yazilar\");
                string yaziId = kontrol.rastgeleID();
                VeriTabaniyazi.yaziId = yaziId;
                VeriTabaniyazi.kisiId = yazı.kisiId;
              
                VeriTabaniyazi.yaziIcerikAdres = adres;
                veritabani.yazilar.Add(VeriTabaniyazi);
                veritabani.SaveChanges();
                yorumTipi yorum = new yorumTipi();
                yazı.yaziId = yaziId;
                yazı.yaziTarih = DateTime.Now;
                yazı.yorumAdres = yorum.yorumYaz(Server, yaziId);
                new yaziTipi(yazı, adres, Server);

                return true;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message + "HATA");
                return false;
            }
        }
        [HttpGet]
        public ActionResult yaziYaz()
        {
            return View();
        }
        /// <summary>
        /// Gelen yazıId bilgisine göre veritabanını sorgulayıp,geri dönen değerleri sayfaya gönderen metod.
        /// </summary>
        /// <param name="yaziId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult yaziOku(string yaziId)
        {
            try
            {
                var yazi = veritabani.yazilar.Where(arama => arama.yaziId == yaziId).First();
                return View(yazi);
            }
            catch
            {
                return View();
            }
        }
    }
}