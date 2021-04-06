using System;

using EntitiesLayer;

using Moq;

using Xunit;

namespace ServiceLayer.Tests
{
    public class MathWebClientTests
    {
        private readonly Mock<IMathWebClient> _mathWebClient;
        private readonly Mock<ILoggerManager> _iloggerManager;

        private readonly MathWebClient _mathWebClientInstance;

        public MathWebClientTests()
        {
            _mathWebClient = new Mock<IMathWebClient>();
            _iloggerManager = new Mock<ILoggerManager>();

            _mathWebClientInstance = new MathWebClient(_iloggerManager.Object);
        }

        [Fact]
        public void AddMethod_ShouldReturn_TheExpectedResult()
        {
            int a = 15, b = 6, expected = a + b;

            _iloggerManager.Setup(mr => mr.Insert(It.IsAny<string>())).Returns(true);

            _mathWebClient.Setup(m => m.Add(a, b)).Returns(a + b);

            var result = _mathWebClientInstance.Add(a, b);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void MultiplyMethod_ShouldReturn_TheExpectedResult()
        {
            int a = 15, b = 6, expected = a * b;

            _iloggerManager.Setup(mr => mr.Insert(It.IsAny<string>())).Returns(true);

            _mathWebClient.Setup(m => m.Multiply(a, b)).Returns(a * b);

            var result = _mathWebClientInstance.Multiply(a, b);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DivideMethod_ShouldReturn_TheExpectedResult()
        {
            int a = 15, b = 6, expected = Convert.ToInt32(a / b);

            _iloggerManager.Setup(mr => mr.Insert(It.IsAny<string>())).Returns(true);

            _mathWebClient.Setup(m => m.Divide(a, b)).Returns(a / b);

            var result = _mathWebClientInstance.Divide(a, b);

            Assert.Equal(expected, result);
        }
    }
}
