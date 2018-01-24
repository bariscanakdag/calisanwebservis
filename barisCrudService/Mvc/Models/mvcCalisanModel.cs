using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcCalisanModel
    {
        public int CalisanID { get; set; }
        [Required(ErrorMessage = "Adı Boş Geçilemez !!!")]
        public string Adi { get; set; }
        public string Pozisyon { get; set; }
        public string Ofis { get; set; }
        public int? Yas { get; set; }
        public int? Maas { get; set; }
    }
}