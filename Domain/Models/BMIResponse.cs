using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class BMIResponse
    {
        public string txtYourBmi { get; set; }
        public string lblMessage { get; set; }
        public string lblMessageError { get; set; }
        public string lblIdealWeight1 { get; set; }
        public string lblIdealWeight2 { get; set; }
    }
}
