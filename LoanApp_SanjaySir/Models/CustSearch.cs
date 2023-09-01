using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoanApp_SanjaySir.Models
{
    public class CustSearch
    {
        [EmailAddress] 
        [Required(ErrorMessage ="Enter Valid Email Address")]
        [DisplayName ("Enter your Email ID ")]
         public string CustEmail { get; set; }
    }
}