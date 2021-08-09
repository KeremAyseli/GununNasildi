using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GununNasıldı.Models.Entity;

namespace GununNasıldı.Controllers
{
    public class YorumlarController : Controller
    {
        gununnasildiEntities4 veriTabani = new gununnasildiEntities4();
        kontrol rastgeleIDIsım = new kontrol();
        // GET: Yorumlar
        public ActionResult Index()
        {
            return View();
        }
        public bool YorumYap(string yorumYazisi,int yorumuYapanKisiId,string yaziIsim)
        {
            try
            {
                var yorumuYapanKisi = veriTabani.kisiler.Where(id => id.kisiId == yorumuYapanKisiId).First();
                yorumTipi yorum = new yorumTipi();
                yorum.YorumuYapanKisi = yorumuYapanKisi;
                yorum.yorumYazısı = yorumYazisi;
                yorum.yorumYaz(Server, yaziIsim,yorumYazisi,yorumuYapanKisi);
                return true;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message + "  hata");
                return false;
            }
        }
        public bool YanitYap(string yanit,string yorumAdres,int yanitiYapanKisiId)
        {
            try
            {
                Yanit yanıt = new Yanit();
                YanitTipi yanitTipi = new YanitTipi();
                yanitTipi.yanitId = rastgeleIDIsım.rastgeleID();
                yanitTipi.YanitlayanKisi= veriTabani.kisiler.Where(id => id.kisiId == yanitiYapanKisiId).First();
                yanitTipi.yanitYazisi = yanit;
               System.Diagnostics.Debug.WriteLine(yanıt.yanıtYap(Server, yorumAdres, yanitTipi));

                return true;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message + " hata");
                return false;
            }
        }
    }
}
