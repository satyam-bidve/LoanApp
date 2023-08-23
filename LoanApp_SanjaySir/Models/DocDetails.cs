using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanApp_SanjaySir.Models
{
    public class DocDetails
    {
       
        public string DocCode { get; set; }
        public string DocumentName { get; set; }
        public byte[] DocumentImage { get; set; }
    }
}