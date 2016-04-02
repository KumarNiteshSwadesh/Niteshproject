using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileRepairSuperMarket.Models;

namespace MobileRepairSuperMarket.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        DataLayer dl = new DataLayer();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NewRegistration(Property p)
        {
            p.UserId = "0";
            int result = dl.INSERT_UPDATE_USER_REGISTRATION(p);
            if(result>0)
            {
                TempData["MSG"]="Data Saved Successfully.";
                ModelState.Clear();
            }
            return View("/LOgin");
        }
    }
}
