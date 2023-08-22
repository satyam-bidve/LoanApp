using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanApp_SanjaySir.Models
{
    public class LoanDetails
    {
        public int LoanCode { get; set; }
        public string LoanType { get; set; }

        public int LoanAmount { get; set; }

        public int RateOfInterest { get; set; }
        public int LoanTenure { get; set; }

        public int EMI { get; set; }
        public string LoanStatus { get; set; }

    }
}