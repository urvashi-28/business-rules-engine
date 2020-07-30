using Business.Rules.Engine.Processors;
using Business.Rules.Engine.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Engine.Handlers
{
    public class ProductPaymentHandler
    {
        private IProductTypeCollection _productTypeCollection;
        private IPhysicalProductProcessor _physicalProductProcessor;

        public ProductPaymentHandler(IProductTypeCollection productTypeCollection, IPhysicalProductProcessor physicalProductProcessor)
        {
            _productTypeCollection = productTypeCollection;
            _physicalProductProcessor = physicalProductProcessor;
        }

        public void Handle(int productId)
        {
            var productType = _productTypeCollection.GetProductType(productId);

            switch(productType)
            {
                case "PhysicalProduct":
                    _physicalProductProcessor.Process();
                    break;
                case "Book":
                    break;
                case "ActivateMembership":
                    break;
                case "UpgradeMembership":
                    break;
                case "Video":
                    break;
                default:
                    break;
            }
        }
    }
}
