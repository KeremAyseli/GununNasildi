using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GununNasıldı.Models.Entity;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
namespace GununNasıldı
{
    public class yorumTipi
    {
        kontrol kontrol = new kontrol();
        
        public void yorumYaz(HttpServerUtilityBase Server,string yaziİsim, string yorumYazisi, kisiler yorumuYapanKisi)
        {
            Debug.WriteLine(yaziİsim+"Yazıİsim");
            yorumAdres = "/yorumlar/"+yaziİsim+"/"+ kontrol.dosyaİsimOlusturma(@"~\yorumlar\"+yaziİsim+@"\");
            YorumId = kontrol.rastgeleID();
            YorumYapılmaTarihi = DateTime.Now;
            Yorumyanıtlar = new List<YanitTipi>();
            yorumYazısı = yorumYazisi;
            YorumuYapanKisi = yorumuYapanKisi;
            Debug.WriteLine(Server.MapPath("~/yorumlar/" + yaziİsim)+"Yazı yorum adres---------------------------------");
            if (!Directory.Exists(Server.MapPath("~/yorumlar/" + yaziİsim))) 
            {
                Directory.CreateDirectory(Server.MapPath("~/yorumlar/" + yaziİsim));
             } 
            File.WriteAllText(Server.MapPath("~/"+yorumAdres), JsonConvert.SerializeObject(this));    
        }
        public string yorumYaz(HttpServerUtilityBase Server, string yaziİsim)
        {
            Debug.WriteLine(yaziİsim + "Yazıİsim");
            yorumAdres = "/yorumlar/" + yaziİsim + "/" + kontrol.dosyaİsimOlusturma(@"~\yorumlar\" + yaziİsim + @"\");
            YorumId = kontrol.rastgeleID();
            YorumYapılmaTarihi = DateTime.Now;
            Yorumyanıtlar = new List<YanitTipi>();
            Debug.WriteLine(Server.MapPath("~/yorumlar/" + yaziİsim) + "Yazı yorum adres---------------------------------");
            if (!Directory.Exists(Server.MapPath("~/yorumlar/" + yaziİsim)))
            {
                Directory.CreateDirectory(Server.MapPath("~/yorumlar/" + yaziİsim));
            }
            File.WriteAllText(Server.MapPath("~/" + yorumAdres), JsonConvert.SerializeObject(this));
            return yorumAdres;
        }

        public List<yorumTipi> yorumOku(HttpServerUtilityBase Server,string yaziİsim)
        {
            System.Diagnostics.Debug.WriteLine(yaziİsim+"okuma işlemi");
            string adres = Server.MapPath("~/yorumlar/" + yaziİsim + @"/");
            var yorumAdresleri = Directory.GetFiles(adres);
            List<yorumTipi> Yapılanyorumlar = new List<yorumTipi>();
            for (int i = 0; i < yorumAdresleri.Length; i++)
            {
                Yapılanyorumlar.Add(JsonConvert.DeserializeObject<yorumTipi>(File.ReadAllText(yorumAdresleri[i])));
            }
            return Yapılanyorumlar;
        }
        public int yorumAdedi(HttpServerUtilityBase Server,string yaziİsim)
        {
            return kontrol.dosyaSayisi(Server,yaziİsim);
        }
        public string yorumAdres { get; set; }
        public string YorumId { get; set; }
        public string yorumYazısı { get; set; }
        public List<YanitTipi> Yorumyanıtlar { get; set; }
        public DateTime YorumYapılmaTarihi { get; set; }
        public kisiler YorumuYapanKisi { get; set; }

    }
}