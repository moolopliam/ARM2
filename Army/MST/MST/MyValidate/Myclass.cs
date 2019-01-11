using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MST.Models
{
    public class Myclass
    {
       
       
        public HttpPostedFileBase MyPic { get; set; }
    

        [Display(Name = "ชื่อ")]
        //[Required(ErrorMessage ="กรุณาตรวจสอบชื่อบัญชี")]
        public string TempName { get; set; }

        //public HttpPostedFileBase FileUpload { get; set; }
    }
    public class ArtTmp
    {
        public DateTime MyDate { get; set; }
    }

   
}