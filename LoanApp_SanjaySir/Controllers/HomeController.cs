using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanApp_SanjaySir.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       

        public ActionResult LoanType() 
        {

            return View();
        }


        public ActionResult LoanDocList()
        {

            return View();
        }

        public ActionResult LinkDocToLoan()
        {

            return View();
        }

        public ActionResult LoanApplication()
        {

            return View();
        }

        public ActionResult LoanHistory()
        {

            return View();
        }

        public ActionResult LogOut()
        {

            return View();
        }
    }
}