using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightTrackingAPI.Controllers;
using Xunit;

namespace XUnitTestWeightTracking
{
    public class BMICalculatorTests
    {


        [Fact]
        public void BMICalculatorResult_ReturnsExpectedResult_ForFemaleAndUnderweight()
        {
            // Arrange
            var calculator = new WeightAPIController();
            var ddlHeight = "Feet";
            var txtHeight = "5.3";
            var txtWeight = "40";
            var rdbGender = "FEMALE";

            // Act
            var result = calculator.BMICalculatorResult(ddlHeight, txtHeight, txtWeight, rdbGender);

            // Assert
            Assert.Equal("That you are too thin.", result.lblMessage);
            Assert.Equal("48.65  KG  ", result.SetlblIdealWeight1);
            Assert.Equal("61.46  KG  ", result.lblIdealWeight2);
        }

        [Fact]
        public void BMICalculatorResult_ReturnsExpectedResult_ForFemaleAndOverWeight()
        {
            // Arrange
            var calculator = new WeightAPIController();
            var ddlHeight = "Inches";
            var txtHeight = "63";
            var txtWeight = "120";
            var rdbGender = "FEMALE";

            // Act
            var result = calculator.BMICalculatorResult(ddlHeight, txtHeight, txtWeight, rdbGender);

            // Assert
            Assert.Equal("That you have overweight.", result.lblMessage);
            Assert.Equal("48.65  KG  ", result.SetlblIdealWeight1);
            Assert.Equal("61.46  KG  ", result.lblIdealWeight2);
        }
        [Fact]
        public void BMICalculatorResult_ReturnsExpectedResult_ForFemaleAndHealthyWeight()
        {
            // Arrange
            var calculator = new WeightAPIController();
            var ddlHeight = "Feet";
            var txtHeight = "5.5";
            var txtWeight = "54";
            var rdbGender = "FEMALE";

            // Act
            var result = calculator.BMICalculatorResult(ddlHeight, txtHeight, txtWeight, rdbGender);

            // Assert
            Assert.Equal("That you are healthy.", result.lblMessage);
            Assert.Equal("51.79  KG  ", result.SetlblIdealWeight1);
            Assert.Equal("65.42  KG  ", result.lblIdealWeight2);
        }
        // Add more test methods for other scenarios...


        [Fact]
        public void BMICalculatorResult_ReturnsExpectedResult_MaleAndUnderweight()
        {
            // Arrange
            var calculator = new WeightAPIController();
            var ddlHeight = "Feet";
            var txtHeight = "5.8";
            var txtWeight = "50";
            var rdbGender = "MALE";

            // Act
            var result = calculator.BMICalculatorResult(ddlHeight, txtHeight, txtWeight, rdbGender);

            // Assert
            Assert.Equal("That you are too thin.", result.lblMessage);
            Assert.Equal("59.66  KG  ", result.SetlblIdealWeight1);
            Assert.Equal("74.58  KG  ", result.lblIdealWeight2);
        }

        [Fact]
        public void BMICalculatorResult_ReturnsExpectedResult_ForMaleAndOverWeight()
        {
            // Arrange
            var calculator = new WeightAPIController();
            var ddlHeight = "Feet";
            var txtHeight = "5.7";
            var txtWeight = "80";
            var rdbGender = "MALE";

            // Act
            var result = calculator.BMICalculatorResult(ddlHeight, txtHeight, txtWeight, rdbGender);

            // Assert
            Assert.Equal("That you have overweight.", result.lblMessage);
            Assert.Equal("57.92  KG  ", result.SetlblIdealWeight1);
            Assert.Equal("72.4  KG  ", result.lblIdealWeight2);
        }
        [Fact]
        public void BMICalculatorResult_ReturnsExpectedResult_ForMaleAndHealthyWeight()
        {
            // Arrange
            var calculator = new WeightAPIController();
            var ddlHeight = "Feet";
            var txtHeight = "5.7";
            var txtWeight = "60";
            var rdbGender = "MALE";

            // Act
            var result = calculator.BMICalculatorResult(ddlHeight, txtHeight, txtWeight, rdbGender);

            // Assert
            Assert.Equal("That you are healthy.", result.lblMessage);
            Assert.Equal("57.92  KG  ", result.SetlblIdealWeight1);
            Assert.Equal("72.4  KG  ", result.lblIdealWeight2);
        }
    }
}


