using LoanApp_SanjaySir.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using LoanApp_SanjaySir.DBContext;

namespace LoanApp_SanjaySir.Controllers
{
    public class HomeController : Controller
    {
        CustomerDetails CustomerFinal; // change here as now insrtace is crated to see its contains object value or not
        int CheckAge ;
        DataContext dbContext;
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

            // setting up databse code ConnString here 
            DataContext dbContext= new DataContext("Data Source = DESKTOP-BV0OTOG\\SQLEXPRESS ; Initial Catalog =LoanAppDataBase ; Integrated Security = true ; multipleactiveresultsets = true ; timeout = 1000; Connection Timeout = 1000;");

            // This is the general validation for Customer details 
            if (ModelState.IsValid)
            {
                //CustomerFinal = customerData; // ⭕⭕⭕⭕⭕⭕  work on this 
                //CheckAge = customerData.Age;
                TempData["age"] = customerData.Age;
               // customerData.LoanID += 1;
                // push Customer to dataBase here 
                dbContext.Constomers.Add(customerData);
                dbContext.SaveChanges();
                return View();// returns view for loan Form
            }
            else
            {
                return View("LoanApplicationForm"); // if input is not valid stay on loanAppliation Form (Customer Deatisl)
            }
            
            
        }

        [HttpPost]
        // on Loan App Form Submit
        public ActionResult DocumentSubmission(LoanDetails loan)
        {

            // setting up databse code ConnString here 
            DataContext dbContext= new DataContext("Data Source = DESKTOP-BV0OTOG\\SQLEXPRESS ; Initial Catalog =LoanAppDataBase ; Integrated Security = true ; multipleactiveresultsets = true ; timeout = 1000; Connection Timeout = 1000;");

            CheckAge = Convert.ToInt32(TempData["age"]);
            bool? IsAgeOk = null;
            // This is General validation for Customer Loan details Validation
           if(ModelState.IsValid)
            {
                int MonthlyInterest;
                if (loan.LoanType.Equals("Vehicle Loan")) // need to check the age as well to meet the reqired sanderd of customer
                {
                   if(CheckAge > 60)
                    {
                        
                        ViewBag.msg = "For Vehical Loan Age must be Under 60 Years";
                        IsAgeOk = true;
                    }
                    else {
                        loan.LoanCode = "L01";
                        loan.LoanStatus = true;
                        loan.RateOfInterest = 8.5f;
                        MonthlyInterest = (int)((loan.LoanAmountReq * (loan.RateOfInterest / 100)) / 12);
                        loan.EMI = (loan.LoanAmountReq / loan.LoanTenure) + MonthlyInterest;
                        // Push Data in database here   
                        dbContext.Loans.Add(loan);
                        dbContext.SaveChanges();
                        return View("DocumentSubmissionForVehicalLoan");
                     }
                    
                    

                }
                else if (loan.LoanType.Equals("Personal Loan"))
                {
                    if (CheckAge > 70)
                    {
                       
                        ViewBag.msg = "For Personal Loan Age must be Under 70 Years";
                        IsAgeOk = true;
                    }
                    else
                    {
                        loan.LoanCode = "L02";
                        loan.LoanStatus = true;
                        loan.RateOfInterest = 12f;
                        MonthlyInterest = (int)((loan.LoanAmountReq * (loan.RateOfInterest / 100)) / 12);
                        loan.EMI = (loan.LoanAmountReq / loan.LoanTenure) + MonthlyInterest;
                        // Push Data in database here
                        dbContext.Loans.Add(loan);
                        dbContext.SaveChanges();
                        return View("DocumentSubmissionForPersonalLoan");

                    }
                    
                }
                else
                {
                    if (CheckAge > 80)
                    {
                        ModelState.AddModelError("Age", "For Gold Loan Age must be Under 80 Years");
                        ViewBag.msg = "For Gold Loan Age must be Under 80 Years";
                        IsAgeOk = true;
                    }
                    else
                    {
                        loan.LoanCode = "L03";
                        loan.LoanStatus = true;
                        loan.RateOfInterest = 14f;
                        MonthlyInterest = (int)((loan.LoanAmountReq * (loan.RateOfInterest / 100)) / 12);
                        loan.EMI = (loan.LoanAmountReq / loan.LoanTenure) + MonthlyInterest;
                        // Push Data in database here
                        dbContext.Loans.Add(loan);
                        dbContext.SaveChanges();
                        return View("DocumentSubmissionForGoldLoan");

                    }
                   
                }
            }
            /*if (ModelState.IsValid)
            {
                //_dbContext.Table Name.Add(loan);
                //_dbContext.saveChanges();
            }*/
            ViewBag.IsAgeOk = IsAgeOk;
            return View("LoanApplicationForm");

            
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

        public ActionResult ShowCustDetails(CustSearch searchID)
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