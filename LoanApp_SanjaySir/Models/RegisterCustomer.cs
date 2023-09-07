using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LoanApp_SanjaySir.Models
{
    public class RegisterCustomer
    {
        [Key] // Define the primary key
        public int Id { get; set; }
        [DisplayName("Name :")]
        public string CustomerName { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Provide a valid Email address")]
        [DisplayName("Email-ID :")]
        public string CustomerEmail { get; set; }
        [DisplayName("Mobile :")]
        public string CustomerPhone { get; set; }

        [DisplayName("Password :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
       


        

    }
}