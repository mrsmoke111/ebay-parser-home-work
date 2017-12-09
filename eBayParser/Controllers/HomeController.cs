using eBayParser.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eBayParser.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var test = EBayItemParser.Parse("https://www.ebay.com/sch/i.html?_odkw=Sports+Mem&_osacat=64482&_from=R40&_trksid=p2045573.m570.l1313.TR0.TRC0.H0.XSports.TRS0&_nkw=Sports&_sacat=64482");
            ViewBag.test = test;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}