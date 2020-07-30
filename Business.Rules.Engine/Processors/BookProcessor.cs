using Business.Rules.Engine.ProductAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Engine.Processors
{
    public interface IBookProcessor
    {
        void Process();
    }

    public class BookProcessor : IBookProcessor
    {
        private IPaymentSlipGenerator _paymentSlipGenerator;

        public BookProcessor(IPaymentSlipGenerator paymentSlipGenerator)
        {
            _paymentSlipGenerator = paymentSlipGenerator;
        }

        public void Process()
        {
            try
            {
                var shippingSlipResult = _paymentSlipGenerator.GenerateShippingSlip() ? "Payment Slip generated successfully" : "Error in generating Payment Slip";
                var duplicateSlipResult = _paymentSlipGenerator.GenerateDuplicateSlip() ? "Duplicate Payment Slip generated successfully" : "Error in generating Duplicate Payment Slip";
                var comissionSlipResult = _paymentSlipGenerator.GenerateComissionSlip() ? "Comission Slip generated successfully" : "Error in generating Comission Slip";

                Console.WriteLine(shippingSlipResult);
                Console.WriteLine(comissionSlipResult);
                Console.WriteLine(duplicateSlipResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
