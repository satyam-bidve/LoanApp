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

        public DateTime ApplicationDate { get => GetDate(); }

        public DateTime DateOfBirth { get; set; }

        public int Age { get => CalculateAge(); }

        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string Gender { get; set; }

        private int CalculateAge()
        {
            int age = (int)Math.Round((DateTime.Now - DateOfBirth).TotalDays / 365.0);    // calculate the difff in terms of days TOTalDays 
            return age;
        }

        private DateTime GetDate() { return  DateTime.Now; }

    }
}