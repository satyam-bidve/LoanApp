using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LoanApp_SanjaySir.Models
{
    public class MasterData
    {
        public int Application { get;  set; } 

       
        public string CustomerName { get; set; } = string.Empty;

        public DateTime ApplicationDate { get; set; }

        
        public DateTime DateOfBirth { get; set; }

        
        public int Age { get; set; }

        
        public string CustomerEmail { get; set; }

       
        public string CustomerPhone { get; set; }
        public string Gender { get; set; }

        public String LoanCode { get; set; }

        public string LoanType { get; set; }

        
        public int LoanAmountReq { get; set; }



        public bool LoanStatus { get; set; }

        public float RateOfInterest { get; set; }
        public int LoanTenure { get; set; }

        public int EMI { get; set; }
    }
}