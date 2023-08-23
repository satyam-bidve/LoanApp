using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LoanApp_SanjaySir.Models
{
    public class DocDetails
    {
       
        public string DocCode { get; set; }

        [DisplayName("Document")]
        public string DocumentName { get; set; }
        
    }
}