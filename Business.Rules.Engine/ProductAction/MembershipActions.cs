using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Engine.ProductAction
{
    public interface IMembershipActions
    {
        bool ActivateMembership();

        bool UpgradeMembership();
    }

    public class MembershipActions : IMembershipActions
    {
        public bool ActivateMembership()
        {
            // oprations to activate memberships. If operation is successful return true else false.
            try
            {
                // Call to send email method will be added here
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public bool UpgradeMembership()
        {
            // oprations to activate memberships. If operation is successful return true else false.
            try
            {
                // Call to send email method will be added here
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
