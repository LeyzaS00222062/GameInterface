using GameInterface;
using NUnit.Framework;
using Moq;
using GameInterface.Services;
namespace GameInterface.Tests
{
    [TestFixture]

    // this is my test class it will contain my unit tests
    // you will need to mock the discount service in your tests
    // you will then take out the mocking for the final system test with selenium
    public class GameTests

    {

        // This is the test class for the InsuranceService
        // Our Unit Tests
        private Mock<DiscountService> _mockDiscountService = null!;
        private InsuranceService _premiumService = null!;

        [SetUp]
        public void Setup()
        {
            _mockDiscountService = new Mock<DiscountService>();
            _premiumService = new InsuranceService(_mockDiscountService.Object);
        }

        [Test]
        public void CalcPremium_Casual_Age25_Returns5()
        {
            // Act
            var result = _premiumService.CalcPremium(25, "casual");

            // Assert
            Assert.That(result, Is.EqualTo(5.0));
        }

        [Test]
        public void CalcPremium_Hardcore_Age50_AppliesDiscount()
        {
           
            // Arrange
            _mockDiscountService.Setup(x => x.GetDiscount()).Returns(0.9);

            // Act
            var result = _premiumService.CalcPremium(50, "hardcore");

            // Assert
            Assert.That(result, Is.EqualTo(4.5));
        }


        [Test]
        public void CalcPremium_AgeBelow18_Returns0()
        {
            // Act
            var resultCasual = _premiumService.CalcPremium(17, "casual");
            var resultHardcore = _premiumService.CalcPremium(17, "hardcore");

            // Assert
            Assert.That(resultCasual, Is.EqualTo(0.0));
            Assert.That(resultHardcore, Is.EqualTo(0.0));
        }

        [Test]
        public void CalcPremium_Casual_AgeAbove30_Returns2_5()
        {
            // Act
            var result = _premiumService.CalcPremium(35, "casual");

            // Assert
            Assert.That(result, Is.EqualTo(2.5));
        }


        [Test]
        public void CalcPremium_InvalidGameMode_Returns0()
        {
            // Act
            var result = _premiumService.CalcPremium(25, "invalidMode");

            // Assert
            Assert.That(result, Is.EqualTo(0.0));
        }

    }
}
