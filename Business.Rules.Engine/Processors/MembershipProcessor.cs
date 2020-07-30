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
        public void ActivateMembership()
        {
            
        }

        public void UpgradeMembership()
        {
            
        }
    }
}
