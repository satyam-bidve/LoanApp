﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoanApp_SanjaySir.Models
{
    public class LoanDetails
    {
        [Key] // Define the primary key
        public int Id { get; set; }
        public string CustomerEmail { get; set; }

        public String LoanCode { get; set; }

        [DisplayName("Loan Type :")]
        public string LoanType { get; set; }

        [DisplayName("Loan Amount Required :")]
        public int LoanAmountReq { get; set; }

        

        public bool LoanStatus { get; set; }

        public float RateOfInterest { get; set; }
        public int LoanTenure { get; set; }

        public int EMI { get; set; }
       

    }
}