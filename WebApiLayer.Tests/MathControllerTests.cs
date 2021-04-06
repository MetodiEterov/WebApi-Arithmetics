using System;

using EntitiesLayer;

using Moq;

using Xunit;

using WebApiLayer.Controllers;

namespace WebApiLayer.Tests
{
    public class MathControllerTests
    {
        private readonly Mock<IMathWebClient> _mockMathWebClient;
        private readonly Mock<ILoggerManager> _iloggerManager;

        private MathController _mathController;

        public MathControllerTests()
        {
            _mockMathWebClient = new Mock<IMathWebClient>();
            _iloggerManager = new Mock<ILoggerManager>();

            _mathController = new MathController(_mockMathWebClient.Object);
        }

        [Fact]
        public void AddMethod_ShouldReturn_TheExpectedResult()
        {
            int a = 15, b = 6, expected = a + b;

            _mockMathWebClient.Setup(m => m.Add(a, b)).Returns(a + b);

            var result = Convert.ToInt32(_mathController.Add(a, b).Content.ReadAsStringAsync().Result);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void MultiplyMethod_ShouldReturn_TheExpectedResult()
        {
            int a = 15, b = 6, expected = a * b;

            _mockMathWebClient.Setup(m => m.Multiply(a, b)).Returns(a * b);

            var result = Convert.ToInt32(_mathController.Multiply(a, b).Content.ReadAsStringAsync().Result);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DivideMethod_ShouldReturn_TheExpectedResult()
        {
            int a = 15, b = 6, expected = a / b;

            _mockMathWebClient.Setup(m => m.Divide(a, b)).Returns(a / b);

            var result = Convert.ToInt32(_mathController.Divide(a, b).Content.ReadAsStringAsync().Result);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DivideMethod_ShouldReturn_InternalServerError_WhenDivideByZero()
        {
            int a = 15, b = 0;

            var result = _mathController.Divide(a, b);

            Assert.Equal("InternalServerError", result.StatusCode.ToString());
        }
    }
}
