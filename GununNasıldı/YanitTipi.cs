using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GununNasıldı.Models.Entity;
namespace GununNasıldı
{
    public class YanitTipi
    {
        public string yanitId { get; set; }
        public kisiler YanitlayanKisi { get; set; }
        public string yanitYazisi { get; set; }
    }
}