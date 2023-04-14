using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class BMIRequest
    {
        public string ddlHeight { get; set; }
        public string txtHeight { get; set; }
        public string txtWeight { get; set; }
        public string rdbGender { get; set; }
    }
}
