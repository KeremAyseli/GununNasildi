using System;
using System.IO;
using Newtonsoft.Json;
using System.Web;

namespace GununNasıldı
{
    public class yaziTipi
    {
        /// <summary>
        /// Bu metod yazıTipinin yapıcı metotudur.Yazıyı json dosya formatında oluşturmayı sağlar.
        /// </summary>
        /// <param name="yazıAdres"></param>
        /// <param name="Server"></param>
        public yaziTipi(string yazıAdres,HttpServerUtilityBase Server)
        {
            string adres = Server.MapPath("~/yazilar/" + yazıAdres);
            string okunanYazi = File.ReadAllText(adres);
            yaziTipi okunanBilgiler= JsonConvert.DeserializeObject<yaziTipi>(okunanYazi);
            kisiId = okunanBilgiler.kisiId;
            yaziBaslik = okunanBilgiler.yaziBaslik;
            yaziId = okunanBilgiler.yaziId;
            yaziTarih = okunanBilgiler.yaziTarih;
            yorumAdres = okunanBilgiler.yorumAdres;
            yazi = okunanBilgiler.yazi;
        }
        /// <summary>
        /// Bu metod yazıTipinin yapıcı metotudur.Yazıyı json dosya formatında oluşturmayı sağlar.
        /// </summary>
        /// <param name="yazıBilgileri"></param>
        /// <param name="adres"></param>
        /// <param name="Server"></param>
        public yaziTipi(yaziTipi yazıBilgileri,string adres,HttpServerUtilityBase Server)
        {
            File.WriteAllText(Server.MapPath("~/yazilar/"+adres), JsonConvert.SerializeObject(yazıBilgileri));
        }
        public yaziTipi()
        {

        }
        public int kisiId { get; set; }
       public string yaziBaslik { get; set; }
        public string yaziId { get; set; }
        public string yazi { get; set; }
        public DateTime yaziTarih { get; set; }
        public string yorumAdres { get; set; }

    }
}