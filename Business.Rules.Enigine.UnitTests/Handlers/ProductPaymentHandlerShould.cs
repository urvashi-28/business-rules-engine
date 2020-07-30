using Business.Rules.Engine.Handlers;
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
        private IProductPaymentHandler productPaymentHandler;

        [SetUp]
        public void Setup()
        {
            productPaymentHandler = new ProductPaymentHandler();
        }
    }
}
