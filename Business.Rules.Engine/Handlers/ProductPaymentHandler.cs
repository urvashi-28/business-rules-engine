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
        public void Handle(int productId)
        {
        }
    }
}
