using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Mvc.Controllers;

namespace Mvc.Controllers
{
    public class CalisanController : Controller
    {
        // GET: Calisan
        public ActionResult Index()
        {
            IEnumerable<mvcCalisanModel> clsList;
            HttpResponseMessage response = GenelDegiskenler.WepApiClient.GetAsync("Calisan").Result;
           clsList = response.Content.ReadAsAsync<IEnumerable<mvcCalisanModel>>().Result;
            return View(clsList);

        }

        public ActionResult EkleYadaDuzenle(int id = 0)
        {
            if (id == 0)
                return View(new mvcCalisanModel());
            else
            {
                HttpResponseMessage response = GenelDegiskenler.WepApiClient.GetAsync("Calisan/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcCalisanModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult EkleYadaDuzenle(mvcCalisanModel cls)
        {
            if (cls.CalisanID == 0)
            {
                HttpResponseMessage response = GenelDegiskenler.WepApiClient.PostAsJsonAsync("Calisan", cls).Result;
                TempData["SuccessMessage"] = "Kayıt Başarılı";
            }
            else
            {
                HttpResponseMessage response = GenelDegiskenler.WepApiClient.PutAsJsonAsync("Calisan/" + cls.CalisanID, cls).Result;
                TempData["SuccessMessage"] = "Düzenleme Başarılı";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = GenelDegiskenler.WepApiClient.DeleteAsync("Calisan/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Silme Başarılı";
            return RedirectToAction("Index");
        }
    }
}

