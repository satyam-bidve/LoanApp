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

        [DataType (DataType.Upload)]
        [Display(Name = " Pan Card") ]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string filePanCard { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = " Adhar Card")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string fileAdharCard { get; set; }


        [DataType(DataType.Upload)]
        [Display(Name = "Electricity bill")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string fileElectricity { get; set; }


        [DataType(DataType.Upload)]
        [Display(Name = "School Cirtificate")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string fileShool { get; set; }


        [DataType(DataType.Upload)]
        [Display(Name = "")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string fileDriving { get; set; }

    }
}