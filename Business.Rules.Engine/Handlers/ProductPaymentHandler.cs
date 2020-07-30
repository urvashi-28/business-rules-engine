using Business.Rules.Engine.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Engine.Handlers
{
    public interface IProductPaymentHandler
    {
        void Handle(int productId);
    }

    public class ProductPaymentHandler : IProductPaymentHandler
    {
        private IProductTypeCollection _productTypeCollection;

        public ProductPaymentHandler(IProductTypeCollection productTypeCollection)
        {
            _productTypeCollection = productTypeCollection;
        }

        public void Handle(int productId)
        {
            var productType = _productTypeCollection.GetProductType(productId);

            switch(productType)
            {
                case "PhysicalProduct":
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
