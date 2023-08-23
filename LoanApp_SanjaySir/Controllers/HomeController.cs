using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanApp_SanjaySir.Controllers
{
    public class HomeController : Controller
    {
        // --------------------------------------------------------- menu page
        public ActionResult Index()
        {
            return View();
        }

       
        //----------------------------------------------------------- loan types Details

        public ActionResult LoanType() 
        {

            return View();
        }

        //------------------------------------------------------------- Loan DOC Details 
        public ActionResult LoanDocList()
        {

            return View();
        }

        //---------------------------------------------------------------- requrired DOC Details 
        public ActionResult LinkDocToLoan()
        {

            return View();
        }
        // ---------------------------------------------------------- Application loan
       

        public ActionResult LoanApplicationForm() // costmer details
        {

            return View();
        }
        public ActionResult LoanAppForm() // loan details
        {
            return View();
        }

        public ActionResult LoanAppFormDocuments()
        {
            return View();
        }


        //---------------------------------------------------------------- Loan History

        public ActionResult LoanHistory()
        {

            return View();
        }

        //---------------------------------------------------------------- EXIT
        public ActionResult LogOut()
        {

            return View();
        }
    }
}