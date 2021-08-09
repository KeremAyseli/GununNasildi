using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GununNasıldı.Models.Entity;

namespace GununNasıldı
{
    public class kisiTipi
    {
        public kisiTipi(int? kisiIdN)
        {
            gununnasildiEntities4 veritabani = new gununnasildiEntities4();
            var kisi = veritabani.kisiler.Where(Id => Id.kisiId == kisiIdN).First();
            kisiId = kisi.kisiId;
            kisiIsim = kisi.kisiIsim;
            kisiSoyisim = kisi.kisiSoyisim;
            kisiEposta = kisi.kisiEposta;
            YaziId = kisi.YaziId;
            kisiResimAdres = kisi.kisiResimAdres;
        }
        public kisiTipi()
        {

        }
         public  int? kisiId { get; set; }
        public string kisiIsim { get; set; }
        public string kisiSoyisim { get; set; }
        public string kisiEposta { get; set; }
        public Nullable<int> YaziId { get; set; }
        public string kisiResimAdres { get; set; }
    }
}