using Business.Rules.Engine.Handlers;
using Business.Rules.Engine.Processors;
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
        private ProductPaymentHandler _productPaymentHandler;
        private Mock<IProductTypeCollection> _mockProductTypeCollection;
        private Mock<IPhysicalProductProcessor> _mockPhysicalProductProcessor;
        private Mock<IBookProcessor> _mockBookProcessor;
        private Mock<IMembershipProcessor> _mockMembershipProcessor;

        [SetUp]
        public void Setup()
        {
            _mockProductTypeCollection = new Mock<IProductTypeCollection>();
            _mockPhysicalProductProcessor = new Mock<IPhysicalProductProcessor>();
            _mockBookProcessor = new Mock<IBookProcessor>();
            _mockMembershipProcessor = new Mock<IMembershipProcessor>();
            _productPaymentHandler = new ProductPaymentHandler(
                _mockProductTypeCollection.Object, 
                _mockPhysicalProductProcessor.Object, 
                _mockBookProcessor.Object, 
                _mockMembershipProcessor.Object);
        }

        [Test]
        public void ProcessPaymentWhereProductIdIsForPhysicalProduct()
        {
            var productId = 1;
            _mockProductTypeCollection.Setup(x => x.GetProductType(productId)).Returns("PhysicalProduct");
            _mockPhysicalProductProcessor.Setup(x => x.Process());

            _productPaymentHandler.Handle(productId);

            _mockProductTypeCollection.Verify(x => x.GetProductType(productId), Times.Once);
            _mockPhysicalProductProcessor.Verify(x => x.Process(), Times.Once);
        }

        [Test]
        public void ThrowExceptionIfProductTypeCollectionThrowsAnException()
        {
            var productId = 1;
            _mockProductTypeCollection.Setup(x => x.GetProductType(productId)).Throws<TimeoutException>();

            Assert.Throws<TimeoutException>(() => _productPaymentHandler.Handle(productId));

            _mockProductTypeCollection.Verify(x => x.GetProductType(productId), Times.Once);
            _mockPhysicalProductProcessor.Verify(x => x.Process(), Times.Never);
            _mockBookProcessor.Verify(x => x.Process(), Times.Never);
        }

        [Test]
        public void ProcessPaymentWhereProductIdIsForBook()
        {
            var productId = 1;
            _mockProductTypeCollection.Setup(x => x.GetProductType(productId)).Returns("Book");
            _mockPhysicalProductProcessor.Setup(x => x.Process());
            _mockBookProcessor.Setup(x => x.Process());

            _productPaymentHandler.Handle(productId);

            _mockProductTypeCollection.Verify(x => x.GetProductType(productId), Times.Once);
            _mockPhysicalProductProcessor.Verify(x => x.Process(), Times.Never);
            _mockBookProcessor.Verify(x => x.Process(), Times.Once);
        }

        [Test]
        public void ProcessPaymentWhereProductIdIsForActivateMembership()
        {
            var productId = 1;
            _mockProductTypeCollection.Setup(x => x.GetProductType(productId)).Returns("ActivateMembership");

            _productPaymentHandler.Handle(productId);

            _mockProductTypeCollection.Verify(x => x.GetProductType(productId), Times.Once);
            _mockPhysicalProductProcessor.Verify(x => x.Process(), Times.Never);
            _mockBookProcessor.Verify(x => x.Process(), Times.Never);
            _mockMembershipProcessor.Verify(x => x.ActivateMembership(), Times.Once);
            _mockMembershipProcessor.Verify(x => x.UpgradeMembership(), Times.Never);
        }

        [Test]
        public void ProcessPaymentWhereProductIdIsForUpgradeMembership()
        {
            var productId = 1;
            _mockProductTypeCollection.Setup(x => x.GetProductType(productId)).Returns("UpgradeMembership");

            _productPaymentHandler.Handle(productId);

            _mockProductTypeCollection.Verify(x => x.GetProductType(productId), Times.Once);
            _mockPhysicalProductProcessor.Verify(x => x.Process(), Times.Never);
            _mockBookProcessor.Verify(x => x.Process(), Times.Never);
            _mockMembershipProcessor.Verify(x => x.ActivateMembership(), Times.Never);
            _mockMembershipProcessor.Verify(x => x.UpgradeMembership(), Times.Once);
        }
    }
}
