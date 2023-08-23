using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LoanApp_SanjaySir.Models
{
    public class CustomerDetails
    {
        public int Application { get => new Random().Next(1111, 10000); } // Application number random

        [DisplayName("Your Full Name")]
        public string CustomerName { get; set; } = string.Empty;

        public DateTime ApplicationDate { get => GetDate(); }

        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public int Age { get => CalculateAge(); }

        [DisplayName("Email")]
        public string CustomerEmail { get; set; }

        [DisplayName("Mobile No")]
        public string CustomerPhone { get; set; }
        public string Gender { get; set; }

        private int CalculateAge()
        {
            int age = (int)Math.Round((DateTime.Now - DateOfBirth).TotalDays / 365.0);    // calculate the difff in terms of days TOTalDays 
            return age;
        }

        private DateTime GetDate() { return  DateTime.Now; }

        /*private int SetAppNo()
        {
            return Math.Round(Random(01, 100));
        }*/

    }
}