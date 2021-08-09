using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GununNasıldı.Models.Entity;
using GununNasıldı.Controllers;
namespace GununNasıldı.Controllers
{
    public class AnasayfaController : Controller
    {
        gununnasildiEntities4 vt = new gununnasildiEntities4();
        Random rnd = new Random();
        // GET: Anasayfa
        public ActionResult Index()
        {
            try
            {
                var tumYazilar = vt.yazilar.ToList();
                var rastgeleYazi = tumYazilar[rnd.Next(tumYazilar.Count)];
                return View("../yazilar/yaziOku", rastgeleYazi);
            }
            catch
            {
                return View("../yazilar/yaziYaz");
            }
        }
       
    }
}