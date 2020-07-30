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
    public class PhysicalProductProcessorShould
    {
        private IPhysicalProductProcessor _physicalProductProcessor;
        private Mock<IPaymentSlipGenerator> _mockPaymentSlipGenerator;

        [SetUp]
        public void Setup()
        {
            _mockPaymentSlipGenerator = new Mock<IPaymentSlipGenerator>();
            _physicalProductProcessor = new PhysicalProductProcessor(_mockPaymentSlipGenerator.Object);
        }
    }
}
