using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WeightTrackingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeightAPIController : ControllerBase
    {
        //private readonly IService<Weight, int> catService;
        public WeightAPIController(/*IService<Weight, int> catService*/)
        {
            //this.catService = catService;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAsync()
        //{

        //    return Ok();
        //}

        [HttpGet]
        [Route("BMICalculator/{ddlHeight}/{txtHeight}/{txtWeight}/{rdbGender}")]
        public BMIResponse BMICalculatorResult(string ddlHeight, string txtHeight, string txtWeight, string rdbGender)
        {
            var list = new BMIResponse();
            var txtYourEmi = "";
            var lblMessage = "";
            var lblMessageError = "";
            var lblIdealWeight1 = "";
            var lblIdealWeight2 = "";
            try
            {
                if (!string.IsNullOrEmpty(txtHeight) && !string.IsNullOrEmpty(txtWeight) && !string.IsNullOrEmpty(ddlHeight))
                {

                    Double height = Convert.ToDouble(txtHeight.Replace("'", ""));
                    string[] splitFeet = height.ToString().Split('.');
                    if (ddlHeight.Replace("'", "") == "Inches")
                    {
                        height = height * 2.54;
                    }
                    else if (ddlHeight.Replace("'", "") == "Feet")
                    {
                        var int_number = splitFeet[0];
                        var float_number = splitFeet[0];
                        if (splitFeet.Length == 1)
                        {
                            int_number = splitFeet[0];
                            float_number = "0";
                        }
                        else
                        {
                            int_number = splitFeet[0];
                            float_number = splitFeet[1];
                        }


                        //double int_number = height - float_number1;
                        double inch = Convert.ToDouble(int_number) * 12;
                        double inch1 = inch + Convert.ToDouble(float_number);
                        height = inch1 * 2.54;

                    }
                    Double weight = Convert.ToDouble(txtWeight.Replace("'", ""));
                    if (weight > 0 && height > 0)
                    {
                        Double finalBmi = weight / ((height / 100) * (height / 100));
                        txtYourEmi = Math.Round(finalBmi, 2).ToString();
                        string MF = rdbGender.Replace("'", "");


                        if (finalBmi < 19 && MF == "FEMALE")
                        {
                            lblMessage = "That you are too thin.";
                            // lblMessage.ForeColor = System.Drawing.Color.Red;
                            double fin = 19 - finalBmi;
                            Double finalBmi1 = finalBmi + fin;
                            double heightInMeters = height / 100.0; // convert height to meters
                            weight = 19 * heightInMeters * heightInMeters;
                            Double Weight2 = 24 * heightInMeters * heightInMeters;
                            lblIdealWeight1 = Math.Round(weight, 2).ToString() + "  KG  ";
                            lblIdealWeight2 = Math.Round(Weight2, 2).ToString() + "  KG  ";


                        }
                        if (finalBmi >= 19 & finalBmi <= 24 & MF == "FEMALE")
                        {
                            lblMessage = "That you are healthy.";
                            //lblMessage.ForeColor = System.Drawing.Color.Green;

                            double heightInMeters = height / 100.0; // convert height to meters
                            weight = 19 * heightInMeters * heightInMeters;
                            Double Weight2 = 24 * heightInMeters * heightInMeters;
                            lblIdealWeight1 = Math.Round(weight, 2).ToString() + "  KG  ";
                            lblIdealWeight2 = Math.Round(Weight2, 2).ToString() + "  KG  ";
                        }
                        if (finalBmi > 24 & MF == "FEMALE")
                        {

                            lblMessage = "That you have overweight.";
                            //ViewBag.lblMessage.ForeColor = System.Drawing.Color.Red;
                            double fin = finalBmi - 24;
                            Double finalBmi1 = finalBmi + fin;
                            double heightInMeters = height / 100.0; // convert height to meters
                            weight = 19 * heightInMeters * heightInMeters;
                            Double Weight2 = 24 * heightInMeters * heightInMeters;
                            lblIdealWeight1 = Math.Round(weight, 2).ToString() + "  KG  ";
                            lblIdealWeight2 = Math.Round(Weight2, 2).ToString() + "  KG  ";

                        }


                        if (finalBmi < 20 && MF == "MALE")
                        {
                            lblMessage = "That you are too thin.";
                            //lblMessage.ForeColor = System.Drawing.Color.Red;
                            double fin = 20 - finalBmi;
                            Double finalBmi1 = finalBmi + fin;
                            double heightInMeters = height / 100.0; // convert height to meters
                            weight = 20 * heightInMeters * heightInMeters;
                            Double Weight2 = 25 * heightInMeters * heightInMeters;
                            lblIdealWeight1 = Math.Round(weight, 2).ToString() + "  KG  ";
                            lblIdealWeight2 = Math.Round(Weight2, 2).ToString() + "  KG  ";
                        }
                        if (finalBmi >= 20 && finalBmi <= 25 && MF == "MALE")
                        {

                            lblMessage = "That you are healthy.";
                            //lblMessage.ForeColor = System.Drawing.Color.Green;

                            double heightInMeters = height / 100.0; // convert height to meters
                            weight = 20 * heightInMeters * heightInMeters;
                            Double Weight2 = 25 * heightInMeters * heightInMeters;
                            lblIdealWeight1 = Math.Round(weight, 2).ToString() + "  KG  ";
                            lblIdealWeight2 = Math.Round(Weight2, 2).ToString() + "  KG  ";

                        }
                        if (finalBmi > 25 && MF == "MALE")
                        {
                            lblMessage = "That you have overweight.";
                            //lblMessage.ForeColor = System.Drawing.Color.Red;
                            double fin = finalBmi - 25;
                            Double finalBmi1 = finalBmi + fin;

                            double heightInMeters = height / 100.0; // convert height to meters
                            weight = 20 * heightInMeters * heightInMeters;
                            Double Weight2 = 25 * heightInMeters * heightInMeters;
                            lblIdealWeight1 = Math.Round(weight, 2).ToString() + "  KG  ";
                            lblIdealWeight2 = Math.Round(Weight2, 2).ToString() + "  KG  ";
                        }
                    }
                    else
                    {

                        lblMessageError = "Please Fill correct values";
                        //lblMessage.ForeColor = System.Drawing.Color.Red;

                    }
                }
                else
                {
                    lblMessageError = "Please Fill correct values";
                }
            }
            catch
            { }
            //list.Add(new { txtYourBmi = txtYourEmi, lblMessage = lblMessage, lblIdealWeight1 = lblIdealWeight1, lblIdealWeight2 = lblIdealWeight2, lblMessageError = lblMessageError });
            list.txtYourBmi = txtYourEmi;
            list.lblMessage = lblMessage;
            list.lblIdealWeight1 = lblIdealWeight1;
            list.lblIdealWeight2 = lblIdealWeight2;
            list.lblMessageError = lblMessageError;


            return list;
        }
    }
}
