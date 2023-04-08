using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightTracking;
using WeightTracking.Controllers;
using WeightTracking.Models;
using Microsoft.EntityFrameworkCore.InMemory;

namespace WeightTrackingTest
{
    public class WeightEntriesControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewWithEntries()
        {
            // Arrange
            var dbContext = GetDbContextWithData();
            var controller = new WeightEntriesController(dbContext);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<WeightEntry>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count);
        }

        private WeightTrackerDbContext GetDbContextWithData()
        {
            var options = new DbContextOptionsBuilder<WeightTrackerDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var dbContext = new WeightTrackerDbContext(options);

            dbContext.WeightEntries.Add(new WeightEntry { Id = 1, Date = DateTime.Now, Weight = 150, UserId = "testuser" });
            dbContext.WeightEntries.Add(new WeightEntry { Id = 2, Date = DateTime.Now.AddDays(-1), Weight = 148, UserId = "testuser" });
            dbContext.SaveChanges();

            return dbContext;
        }
    }
}