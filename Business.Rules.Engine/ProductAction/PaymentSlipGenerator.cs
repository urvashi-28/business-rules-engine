using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Engine.ProductAction
{
    public interface IPaymentSlipGenerator
    {
        bool GenerateShippingSlip();

        bool GenerateDuplicateSlip();

        bool GenerateComissionSlip();
    }

    public class PaymentSlipGenerator : IPaymentSlipGenerator
    {
        public bool GenerateComissionSlip()
        {
            // oprations to generate actual slip. If operation is successful return true else false.
            try
            {
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public bool GenerateDuplicateSlip()
        {
            // oprations to generate actual slip. If operation is successful return true else false.
            try
            {
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public bool GenerateShippingSlip()
        {
            // oprations to generate actual slip. If operation is successful return true else false.
            try
            {
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
