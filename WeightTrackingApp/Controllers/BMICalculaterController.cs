using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Core_WebApp.Controllers
{
    /// <summary>
    /// Contains action methods (methods those will be executed over HttpRequest)
    /// ActionMethos can be either HttpGet (Default) or HttpPost(HttpPut/HttpDelete)
    /// ActionMethod Retuens IActionResult interface
    /// </summary>
    public class BMICalculaterController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        /// <summary>
        /// Inject the WeightRepository as constructor injection
        /// </summary>
        public BMICalculaterController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Tips()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> BMICalculatorResult(string ddlHeight, string txtHeight, string txtWeight, string rdbGender)
        {
            //var client = _clientFactory.CreateClient();
            //var response12 = await client.GetAsync("https://localhost:7178/api/WeightAPI");


            BMIRequest request = new BMIRequest()
            {
                ddlHeight = ddlHeight,
                txtHeight = txtHeight,
                txtWeight = txtWeight,
                rdbGender = rdbGender
            };



            // Serialize the model to JSON
            string json = JsonSerializer.Serialize(request);

            // Create a StringContent object from the JSON string
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send the POST request to the API
            var client = _clientFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7178/api/WeightAPI/BMICalculator/" + ddlHeight + "/" + txtHeight + "/" + txtWeight + "/" + rdbGender);


            // HttpResponseMessage response = await client.PostAsync("https://localhost:7178/api/WeightAPI", content);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response body to a MyModel object
                string responseJson = await response.Content.ReadAsStringAsync();
                BMIResponse responseModel = JsonSerializer.Deserialize<BMIResponse>(responseJson);

                // Do something with the response model
                return Json(responseModel);
            }
            else
            {

                BMIResponse responseError = new BMIResponse();
                responseError.lblMessageError = "Something went wrong,Please try again later";
                return Json(responseError);

            }
        }
    }
}
