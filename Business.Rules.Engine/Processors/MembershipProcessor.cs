using Business.Rules.Engine.ProductAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Engine.Processors
{
    public interface IMembershipProcessor
    {
        void ActivateMembership();

        void UpgradeMembership();
    }

    public class MembershipProcessor : IMembershipProcessor
    {
        private IMembershipActions _membershipActions;

        public MembershipProcessor(IMembershipActions membershipActions)
        {
            _membershipActions = membershipActions;
        }

        public void ActivateMembership()
        {
            try
            {
                var membershipResult = _membershipActions.ActivateMembership() ? "Membership Activated" : "Error in activating membership";

                Console.WriteLine(membershipResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpgradeMembership()
        {
            try
            {
                var membershipResult = _membershipActions.UpgradeMembership() ? "Membership Upgraded" : "Error in upgradation membership";

                Console.WriteLine(membershipResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}