using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LoanApp_SanjaySir.Models
{
    public class CustomerDetails
    {
        public CustomerDetails()
        {
            Application = SetAppNo();
        }
        public int Application { get; private set; } // Application number random seeting only ones by constuctor 

        [Required(ErrorMessage ="Please Enter Your Name")]
        [DisplayName("Your Full Name")]
        public string CustomerName { get; set; } = string.Empty;

        public DateTime ApplicationDate { get => GetDate(); }

        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Range(18,80)]
        public int Age { get => CalculateAge(); }

        [EmailAddress(ErrorMessage = "Provide a valid Email address")]
        [DisplayName("Email")]
        public string CustomerEmail { get; set; }

        [RegularExpression("^\\d{10}$", ErrorMessage = "Enter a valid Mobile no")]
        [DisplayName("Mobile No")]
        public string CustomerPhone { get; set; }
        public string Gender { get; set; }

        private int CalculateAge()
        {
            int age = (int)Math.Round((DateTime.Now - DateOfBirth).TotalDays / 365.0);    // calculate the difff in terms of days TOTalDays 
            return age;
        }

        private DateTime GetDate() { return  DateTime.Now; }

        private int SetAppNo()
        {
            return (Convert.ToInt32(new Random().Next(1111, 10000)));
        }

    }
}