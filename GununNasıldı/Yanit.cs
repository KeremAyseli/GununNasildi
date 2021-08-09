using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
namespace GununNasıldı
{
    public class Yanit
    {
        kontrol kontrol = new kontrol();
        public bool yanıtYap(HttpServerUtilityBase Server,string yorumadres,YanitTipi yanit)
        {
            string adres = Server.MapPath(@"~/"+yorumadres);
            Debug.WriteLine(adres+ "          " +yorumadres);
            try
            {
                yorumTipi yorum = JsonConvert.DeserializeObject<yorumTipi>(File.ReadAllText(Server.MapPath("~/"+yorumadres)));
                yorum.Yorumyanıtlar.Add(yanit);
                File.WriteAllText(adres, JsonConvert.SerializeObject(yorum));
                Debug.WriteLine(JsonConvert.SerializeObject(yorum) + " yanıt");
                return true;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message + "  yanıt yapmada hata");
                return false;
            }
            
           
           
        }
        
    }
}