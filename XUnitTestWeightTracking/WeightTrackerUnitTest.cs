using Domain.DomainClasses;
using Domain.IService;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using NuGet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightTrackingAPI.Controllers;
using Xunit;

namespace XUnitTestWeightTracking
{
    public class WeightTrackerUnitTest
    {

        private readonly Mock<IWeightHistoryService> _serviceMock;
        private readonly WeightHistoryAPIController _controller;

        public WeightTrackerUnitTest()
        {
            _serviceMock = new Mock<IWeightHistoryService>();
            _controller = new WeightHistoryAPIController(_serviceMock.Object);
        }



        [Fact]
        public async Task GetById_ReturnsWeightHistory_WhenWeightHistoryExists()
        {
            // Arrange
            var weightHistory = new WeightHistory { Id = 1, Date = DateTime.Now.Date, Value = 80 };
            _serviceMock.Setup(s => s.GetAsync(It.IsAny<int>())).ReturnsAsync(weightHistory);

            // Act
            var result = await _controller.Get(1);


            var jaon = result.Result.ToJson();

            WeightHistoryResponse response = JsonConvert.DeserializeObject<WeightHistoryResponse>(jaon);

            Assert.Equal(1, response.Value.Id);
        }



        //[Fact]
        //public async Task Update_ReturnsNoContent_WhenWeightHistoryIsUpdated()
        //{
        //    // Arrange
        //    var weightHistory = new WeightHistory { Id = 1, Date = DateTime.Now.Date, Value = 80 };

        //    // Act
        //    var result = await _controller.Put(1, weightHistory);

        //    // Assert
        //    Assert.IsType<NoContentResult>(result);
        //}
    }
}
