using Business.Rules.Engine.Processors;
using Business.Rules.Engine.ProductAction;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Enigine.UnitTests.Processors
{
    [TestFixture]
    class BookProcessorShould
    {
        private IBookProcessor _bookProcessor;
        private Mock<IPaymentSlipGenerator> _mockPaymentSlipGenerator;

        [SetUp]
        public void Setup()
        {
            _mockPaymentSlipGenerator = new Mock<IPaymentSlipGenerator>();
            _bookProcessor = new BookProcessor(_mockPaymentSlipGenerator.Object);
        }

        [Test]
        public void ProcessShippingPlusDuplicateAndCommissionSlipWhenSlipGeneratorReturnedTrue()
        {
            _mockPaymentSlipGenerator.Setup(m => m.GenerateComissionSlip()).Returns(true);
            _mockPaymentSlipGenerator.Setup(m => m.GenerateShippingSlip()).Returns(true);
            _mockPaymentSlipGenerator.Setup(m => m.GenerateDuplicateSlip()).Returns(true);

            _bookProcessor.Process();

            _mockPaymentSlipGenerator.Verify(m => m.GenerateComissionSlip(), Times.Once);
            _mockPaymentSlipGenerator.Verify(m => m.GenerateShippingSlip(), Times.Once);
            _mockPaymentSlipGenerator.Verify(m => m.GenerateDuplicateSlip(), Times.Once);
        }

        [Test]
        public void ThrowTimeoutExceptionIfGenerateComissionSlipThrowsTimeoutException()
        {
            _mockPaymentSlipGenerator.Setup(m => m.GenerateComissionSlip()).Throws<TimeoutException>();
            _mockPaymentSlipGenerator.Setup(m => m.GenerateShippingSlip()).Returns(true);
            _mockPaymentSlipGenerator.Setup(m => m.GenerateDuplicateSlip()).Returns(true);

            Assert.Throws<TimeoutException>(() => _bookProcessor.Process());

            _mockPaymentSlipGenerator.Verify(m => m.GenerateComissionSlip(), Times.Once);
            _mockPaymentSlipGenerator.Verify(m => m.GenerateShippingSlip(), Times.Once);
            _mockPaymentSlipGenerator.Verify(m => m.GenerateDuplicateSlip(), Times.Once);
        }

        [Test]
        public void ThrowTimeoutExceptionIfGenerateShippingSlipThrowsTimeoutException()
        {
            _mockPaymentSlipGenerator.Setup(m => m.GenerateComissionSlip()).Returns(true);
            _mockPaymentSlipGenerator.Setup(m => m.GenerateShippingSlip()).Throws<TimeoutException>();
            _mockPaymentSlipGenerator.Setup(m => m.GenerateDuplicateSlip()).Returns(true);

            Assert.Throws<TimeoutException>(() => _bookProcessor.Process());

            _mockPaymentSlipGenerator.Verify(m => m.GenerateComissionSlip(), Times.Never);
            _mockPaymentSlipGenerator.Verify(m => m.GenerateDuplicateSlip(), Times.Never);
            _mockPaymentSlipGenerator.Verify(m => m.GenerateShippingSlip(), Times.Once);
        }

        [Test]
        public void ThrowTimeoutExceptionIfGenerateDuplicateSlipThrowsTimeoutException()
        {
            _mockPaymentSlipGenerator.Setup(m => m.GenerateComissionSlip()).Returns(true);
            _mockPaymentSlipGenerator.Setup(m => m.GenerateShippingSlip()).Returns(true);
            _mockPaymentSlipGenerator.Setup(m => m.GenerateDuplicateSlip()).Throws<TimeoutException>();

            Assert.Throws<TimeoutException>(() => _bookProcessor.Process());

            _mockPaymentSlipGenerator.Verify(m => m.GenerateComissionSlip(), Times.Never);
            _mockPaymentSlipGenerator.Verify(m => m.GenerateDuplicateSlip(), Times.Once);
            _mockPaymentSlipGenerator.Verify(m => m.GenerateShippingSlip(), Times.Once);
        }
    }
}
