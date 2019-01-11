using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace MST.Models
{ 
    public class Upload
    {
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public HttpPostedFileBase FileUpload { get; set; }
        





    }
}