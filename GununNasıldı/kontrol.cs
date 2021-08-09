using System;
using System.IO;
using System.Web;
using System.Diagnostics;
namespace GununNasıldı
{
    public class kontrol
    {
        Random rnd = new Random();
        public string dosyaİsimOlusturma(string Adres)
        {
            
            int x = (rnd.Next(1000) / 20) * 19;
            int zaman = DateTime.Now.Millisecond;
            if (System.IO.File.Exists(Adres + "Veri" + x.ToString() + "-" + zaman.ToString() + ".json") == false)
            {
                return "Veri" + x.ToString() + "-" + zaman.ToString() + ".json";
            }
            else
            {
                dosyaİsimOlusturma(Adres);
            }
            return "boş";
        }
        public string rastgeleID()
        {
            char[] alfabe = { 'a', 'b', 'c', 'd', 'e', 'f', 'g','h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'r', 's',  't', 'u', 'v', 'y', 'z' };
            string rastgeleAdres = "";
            for(int i = 0; i < 17; i++)
            {
                rastgeleAdres += alfabe[rnd.Next(alfabe.Length-1)].ToString();
            }
            return + DateTime.Now.Second % 2 == 0 ? rastgeleAdres+"a": rastgeleAdres+"b";
        }
        public void klasorOlusturma(HttpServerUtilityBase Server,string klasorAdi)
        {
            Debug.WriteLine(klasorAdi+" Klasör adı");
            if (!Directory.Exists(Server.MapPath("~/yorumlar/"+klasorAdi)))
            {
                Directory.CreateDirectory(Server.MapPath("~/yorumlar/"+klasorAdi));
            }
            else
            {
                klasorOlusturma(Server,klasorAdi);
            }
        }
        public string BelgeOlusturma(HttpServerUtilityBase Server, string klasorAdi,object Icerik)
        {
            if (!File.Exists(Server.MapPath("~/yorumlar/" + klasorAdi+@"/"+dosyaİsimOlusturma("~/yorumlar/" + klasorAdi + @"/"))))
            {
                string belgeİsim = "/yorumlar/" + klasorAdi + @"/" + dosyaİsimOlusturma("~/yorumlar/" + klasorAdi + @"/");
                File.WriteAllText(Server.MapPath("~"+belgeİsim),Icerik.ToString());
                return belgeİsim;
            }
            else
            {
                klasorOlusturma(Server, klasorAdi);
            }
            return " ";
        }
        public int dosyaSayisi(HttpServerUtilityBase Server,string adres)
        {
          System.Diagnostics.Debug.WriteLine(Server.MapPath("~/yorumlar/" + adres + @"\"));
          return Directory.GetFiles(Server.MapPath("~/yorumlar/"+adres+@"\")).Length;
        }
    }
}