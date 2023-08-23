using LoanApp_SanjaySir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*Rough data 
 loanTypesDict.Add("L01", "Vehicle Loan");
    loanTypesDict.Add("L02", "Personal Loan");
    loanTypesDict.Add("L03", "Gold Loan");

   MonthlyEMI = (LoanAmount / LoanTenure) + MonthlyInterest;
   MonthlyInterest = (int)((LoanAmount * (LoanInterestRate / 100)) / 12);
 */

namespace LoanApp_SanjaySir.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public void GetCustomerForm(CustomerDetails customer)
        {
            // Data Recived
            Console.WriteLine(customer.CustomerName);
        }


        public void GetLoanAppForm(LoanDetails loan)
        {
            int MonthlyInterest;
            if (loan.LoanType.Equals("Vehicle Loan")) 
                {
                   loan.LoanCode = "L01";
                   loan.LoanStatus = true;
                   loan.RateOfInterest = 8.5f;
                   MonthlyInterest = (int)((loan.LoanAmountReq * (loan.RateOfInterest / 100)) / 12);
                   loan.EMI = (loan.LoanAmountReq / loan.LoanTenure) + MonthlyInterest;


                }
            else if(loan.LoanType.Equals("Personal Loan"))
            {
                loan.LoanCode = "L02";
                loan.LoanStatus = true;
                loan.RateOfInterest = 12f;
                MonthlyInterest = (int)((loan.LoanAmountReq * (loan.RateOfInterest / 100)) / 12);
                loan.EMI = (loan.LoanAmountReq / loan.LoanTenure) + MonthlyInterest;
            }
            else
            {
                loan.LoanCode = "L03";
                loan.LoanStatus = true;
                loan.RateOfInterest = 14f;
                MonthlyInterest = (int)((loan.LoanAmountReq * (loan.RateOfInterest / 100)) / 12);
                loan.EMI = (loan.LoanAmountReq / loan.LoanTenure) + MonthlyInterest;
            }
            Console.WriteLine(loan);

        }

        public void GetDocForm(DocDetails doc)
        {
            Console.WriteLine(doc.DocumentName);
        }

    }
}