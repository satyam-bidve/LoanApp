using LoanApp_SanjaySir.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
       
        //CustomerForm 1️⃣
        public ActionResult LoanApplicationForm() // costmer details
        {

            return View();
        }


        [HttpPost]
        // on customer form Submit 
        public ActionResult LoanAppForm(CustomerDetails customerData) // loan details
        {
            // push Customer to dataBase here 
            return View();// returns view for loan Form
        }

        [HttpPost]
        // on Loan App Form Submit
        public ActionResult DocumentSubmission(LoanDetails loan)
        {

            int MonthlyInterest;
            if (loan.LoanType.Equals("Vehicle Loan"))
            {
                loan.LoanCode = "L01";
                loan.LoanStatus = true;
                loan.RateOfInterest = 8.5f;
                MonthlyInterest = (int)((loan.LoanAmountReq * (loan.RateOfInterest / 100)) / 12);
                loan.EMI = (loan.LoanAmountReq / loan.LoanTenure) + MonthlyInterest;
                // Push Data in database here
                return View("DocumentSubmissionForVehicalLoan");

            }
            else if (loan.LoanType.Equals("Personal Loan"))
            {
                loan.LoanCode = "L02";
                loan.LoanStatus = true;
                loan.RateOfInterest = 12f;
                MonthlyInterest = (int)((loan.LoanAmountReq * (loan.RateOfInterest / 100)) / 12);
                loan.EMI = (loan.LoanAmountReq / loan.LoanTenure) + MonthlyInterest;
                // Push Data in database here
                return View("DocumentSubmissionForPersonalLoan");
            }
            else
            {
                loan.LoanCode = "L03";
                loan.LoanStatus = true;
                loan.RateOfInterest = 14f;
                MonthlyInterest = (int)((loan.LoanAmountReq * (loan.RateOfInterest / 100)) / 12);
                loan.EMI = (loan.LoanAmountReq / loan.LoanTenure) + MonthlyInterest;
                // Push Data in database here
                return View("DocumentSubmissionForGoldLoan");
            }

            
        }
        [HttpPost]
        public ActionResult ApplicationSubmission(DocDetails model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var file in model.Files)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            string fileName = Path.GetFileName(file.FileName);
                            string path = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
                            file.SaveAs(path);
                        }
                    }
                    ViewBag.FileStatus = "Files uploaded successfully.";
                }
                catch (Exception)
                {
                    ViewBag.FileStatus = "Error while uploading files.";
                }

            }
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