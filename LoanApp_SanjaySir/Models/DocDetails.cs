using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace LoanApp_SanjaySir.Models
{
    public class DocDetails
    {
       
        public string DocCode { get; set; }

        
        [DataType(DataType.Upload)]
        public List <HttpPostedFileBase> Files { get; set; }
    }
}