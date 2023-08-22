using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanApp_SanjaySir.Models
{
    public class CustomerDetails
    {
        public int CustCode { get; set; }
        public int ApplicationNumber { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public DateTime ApplicationDate { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string Gender { get; set; }

       

    }
}