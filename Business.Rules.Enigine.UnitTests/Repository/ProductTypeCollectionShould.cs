using Business.Rules.Engine.Repository;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Enigine.UnitTests.Repository
{
    [TestFixture]
    public class ProductTypeCollectionShould
    {
        private ProductTypeCollection productTypeCollection;

        [SetUp]
        public void Setup()
        {
            productTypeCollection = new ProductTypeCollection();
        }

        [TestCase(1, "PhysicalProduct")]
        [TestCase(3, "Book")]
        [TestCase(6, "UpgradeMembership")]
        [Test]
        public void ReturnExpetedProductTypeWhenProductIdPassed(int productId, string expectedProductType)
        {
            var actualProductType = productTypeCollection.GetProductType(productId);

            actualProductType.Should().Be(expectedProductType);
        }
    }
}
