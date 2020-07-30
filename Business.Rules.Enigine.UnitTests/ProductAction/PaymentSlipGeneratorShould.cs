using Business.Rules.Engine.ProductAction;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Enigine.UnitTests.ProductAction
{
    [TestFixture]
    public class PaymentSlipGeneratorShould
    {
        private IPaymentSlipGenerator _paymentSlipGenerator;

        [SetUp]
        public void Setup()
        {
            _paymentSlipGenerator = new PaymentSlipGenerator();
        }

        [Test]
        public void GenerateCommissionSlip()
        {
            var result = _paymentSlipGenerator.GenerateComissionSlip();

            result.Should().BeTrue();
        }

        [Test]
        public void GenerateDuplicateSlip()
        {
            var result = _paymentSlipGenerator.GenerateDuplicateSlip();

            result.Should().BeTrue();
        }

        [Test]
        public void GenerateShippingSlip()
        {
            var result = _paymentSlipGenerator.GenerateShippingSlip();

            result.Should().BeTrue();
        }
    }
}
