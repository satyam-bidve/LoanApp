using LoanApp_SanjaySir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            Console.WriteLine(loan.LoanType);
        }

        public void GetDocForm(DocDetails doc)
        {
            Console.WriteLine(doc.DocumentName);
        }

    }
}