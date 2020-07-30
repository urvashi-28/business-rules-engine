using Business.Rules.Engine.Handlers;
using Business.Rules.Engine.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Enigine.UnitTests.Handlers
{
    [TestFixture]
    public class ProductPaymentHandlerShould
    {
        private IProductPaymentHandler _productPaymentHandler;
        private Mock<IProductTypeCollection> _mockProductTypeCollection;

        [SetUp]
        public void Setup()
        {
            _mockProductTypeCollection = new Mock<IProductTypeCollection>();
            _productPaymentHandler = new ProductPaymentHandler(_mockProductTypeCollection.Object);
        }
    }
}
