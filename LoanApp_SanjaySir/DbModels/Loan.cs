using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LoanApp_SanjaySir.DbModels
{
    public class Loan
    {
        public int id { get; set; }
        public String LoanCode { get; set; }

      
        public string LoanType { get; set; }

       
        public int LoanAmountReq { get; set; }



        public bool LoanStatus { get; set; }

        public float RateOfInterest { get; set; }
        public int LoanTenure { get; set; }

        public int EMI { get; set; }
    }
}