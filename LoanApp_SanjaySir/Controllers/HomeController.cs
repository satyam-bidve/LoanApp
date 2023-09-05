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
        string matchMail;
        //DataContext dbContext;
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
        // ---------------------------------------------------------- Application loan transaction 
       
        //CustomerForm 1️⃣
        public ActionResult LoanApplicationForm() // costmer details
        {
            // display form
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
               customerData.Age = (int)Math.Round((DateTime.Now - customerData.DateOfBirth).TotalDays / 365.0);
                customerData.ApplicationDate = DateTime.Now;
                TempData["age"] = customerData.Age;
                TempData["mail"] = customerData.CustomerEmail;
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
            matchMail = (string)TempData["mail"];
            // This is General validation for Customer Loan details Validation
           if (ModelState.IsValid)
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
                        loan.CustomerEmail = matchMail;
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
                        loan.CustomerEmail = matchMail;
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
                        loan.CustomerEmail = matchMail;
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

            
            return View();
        }

      


        //---------------------------------------------------------------- Loan History

        public ActionResult LoanHistory()
        {
            DataContext dbContext = new DataContext("Data Source = DESKTOP-BV0OTOG\\SQLEXPRESS ; Initial Catalog =LoanAppDataBase ; Integrated Security = true ; multipleactiveresultsets = true ; timeout = 1000; Connection Timeout = 1000;");

            var customerRecords = dbContext.Constomers.ToList();
            var LoanRecords = dbContext.Loans.ToList();

            ViewBag.CustomerRecords = customerRecords;
            ViewBag.Loans = LoanRecords;

            return View();
        }

        public ActionResult ShowCustDetails(CustSearch searchID)
        {
            
            DataContext dbContext = new DataContext("Data Source = DESKTOP-BV0OTOG\\SQLEXPRESS ; Initial Catalog =LoanAppDataBase ; Integrated Security = true ; multipleactiveresultsets = true ; timeout = 1000; Connection Timeout = 1000;");

            var customerRecords = dbContext.Constomers.ToList();
            var LoanRecords = dbContext.Loans.ToList();
            // we can pass these lists by viewbag to view directly and then loop through it to print all data (Show All Cust Details)
            MasterData master = new MasterData();
            // here we found the objects (record from databse ) in list - loop through it and match with our serachID Email 
            foreach(var record in customerRecords)
            {
                if (record.CustomerEmail.Equals(searchID.CustEmail)) 
                {

                    // create new model that will hold all data for customer as well as loan assigne the record value to it 
                    master.Application = record.Application;
                    master.CustomerName = record.CustomerName;
                    master.CustomerEmail = record.CustomerEmail;
                    master.ApplicationDate = record.ApplicationDate;
                    master.DateOfBirth = record.DateOfBirth;
                    master.Age= record.Age;
                    master.CustomerPhone = record.CustomerPhone;
                    master.Gender= record.Gender;
                }
            }
            foreach (var record in LoanRecords)
            {
                if (record.CustomerEmail.Equals(searchID.CustEmail))
                {

                    // create new model that will hold all data for customer as well as loan assigne the record value to it 
                    master.LoanCode= record.LoanCode;
                    master.LoanType= record.LoanType;
                    master.LoanAmountReq= record.LoanAmountReq;
                    master.LoanStatus= record.LoanStatus;
                    master.RateOfInterest= record.RateOfInterest;
                    master.LoanTenure= record.LoanTenure;
                    master.EMI= record.EMI;
                }
            }
            
            return View(master);
        }

        //---------------------------------------------------------------- EXIT
        public ActionResult LogOut()
        {

            return View();
        }
    }
}