using Domain.DomainClasses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System;
using System.Net.Http.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace WeightTrackingApp.Controllers
{
    [Authorize]
    public class WeightTrackingController : Controller
    {
        private readonly HttpClient _client;

        public WeightTrackingController(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://localhost:7178"); // Replace with the base URL of your API
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("/api/WeightHistoryAPI");
            response.EnsureSuccessStatusCode();
            var weights = await response.Content.ReadFromJsonAsync<IEnumerable<WeightHistory>>();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            weights = weights.Where(x => x.Fk_UserId == userId).ToList();

            return View(weights);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _client.GetAsync($"/api/WeightHistoryAPI/{id}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            response.EnsureSuccessStatusCode();
            var weight = await response.Content.ReadFromJsonAsync<WeightHistory>();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            weight.Fk_UserId = userId;
            return View(weight);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WeightHistory weight)
        {
            if (!ModelState.IsValid)
            {
                return View(weight);
            }
            // Get the user id of the currently logged in user
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            weight.Fk_UserId = userId;
            var response = await _client.PostAsJsonAsync("/api/WeightHistoryAPI", weight);
            response.EnsureSuccessStatusCode();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {

            var response = await _client.GetAsync($"/api/WeightHistoryAPI/{id}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            response.EnsureSuccessStatusCode();
            var weight = await response.Content.ReadFromJsonAsync<WeightHistory>();
            return View(weight);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, WeightHistory weight)
        {
            if (id != weight.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                weight.Fk_UserId = userId;
                return View(weight);
            }
            var response = await _client.PutAsJsonAsync($"/api/WeightHistoryAPI/{id}", weight);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            response.EnsureSuccessStatusCode();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _client.GetAsync($"/api/WeightHistoryAPI/{id}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            response.EnsureSuccessStatusCode();
            var weight = await response.Content.ReadFromJsonAsync<WeightHistory>();
            return View(weight);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _client.DeleteAsync($"/api/WeightWeightHistoryAPIHistory/{id}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            response.EnsureSuccessStatusCode();
            return RedirectToAction(nameof(Index));
        }
    }
}
