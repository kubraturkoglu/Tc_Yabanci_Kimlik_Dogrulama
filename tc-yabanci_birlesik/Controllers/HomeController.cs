using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tc_yabanci_birlesik.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }

       
        public ActionResult Yabanci()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Yabanci(long tcno, string isim, string soyad, int dogumgun, int dogumay, int dogumyil)
        {
            bool durum;

            try
            {
                using (dogrulama.KPSPublicYabanciDogrulaSoapClient service = new
                    dogrulama.KPSPublicYabanciDogrulaSoapClient
                { })
                {
                    durum = service.YabanciKimlikNoDogrula(tcno, isim, soyad, dogumgun, dogumay, dogumyil);

                    if (durum)
                    {
                        ModelState.AddModelError("", "Dogru ");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Yanlış ");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return View();
        }

        public ActionResult TcVatandas()
        {

            return View();
        }

        [HttpPost]
        public ActionResult TcVatandas(long tcno, string isim, string soyad, int dogumyil)
        {
            bool durum;

            try
            {
                using (KimlikDogrula.KPSPublicSoapClient service = new
                    KimlikDogrula.KPSPublicSoapClient
                { })
                {
                    durum = service.TCKimlikNoDogrula(tcno, isim, soyad, dogumyil);

                    if (durum)
                    {
                        ModelState.AddModelError("", "Dogru ");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Yanlış ");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }


            return View();


        }

    }
}