using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LoanApp_SanjaySir.DbModels
{
    public class Constomer
    {
        public int id { get; set; }
        public int Application { get; set; }


        public string CustomerName { get; set; } = string.Empty;

        public DateTime ApplicationDate { get; set; }


        public DateTime DateOfBirth { get; set; }


        public int Age { get; set; }


        public string CustomerEmail { get; set; }


        public string CustomerPhone { get; set; }
        public string Gender { get; set; }

        public int LoanID { get; set; }

         public virtual Loan loan {get; set;}

    }
}