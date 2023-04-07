using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeightTracking.Models;

namespace WeightTracking.Controllers
{
    public class WeightEntriesController : Controller
    {
        private readonly WeightTrackerDbContext _dbContext;

        public WeightEntriesController(WeightTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var entries = await _dbContext.WeightEntries.ToListAsync();
            return View(entries);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WeightEntry entry)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(entry);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entry);
        }
    }
}
