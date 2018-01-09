using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            if (User.IsInRole("Admin"))
            {
                return View("AdminIndex");
            }
            else if (User.IsInRole("Seller"))
            {
                return View("SellerIndex");
            }

            return View();
        }


        //[Authorize(Roles ="Admin")]
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