using Business.Rules.Engine.ProductAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Engine.Processors
{
    public interface IPhysicalProductProcessor
    {
        
    }

    public class PhysicalProductProcessor : IPhysicalProductProcessor
    {
        private IPaymentSlipGenerator _paymentSlipGenerator;

        public PhysicalProductProcessor(IPaymentSlipGenerator paymentSlipGenerator)
        {
            _paymentSlipGenerator = paymentSlipGenerator;
        }

    }
}
