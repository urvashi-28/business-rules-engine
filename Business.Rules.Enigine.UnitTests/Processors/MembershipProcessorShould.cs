using Business.Rules.Engine.Processors;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Enigine.UnitTests.Processors
{
    [TestFixture]
    public class MembershipProcessorShould
    {
        private IMembershipProcessor _membershipProcessor;

        [SetUp]
        public void Setup()
        {
            _membershipProcessor = new MembershipProcessor();
        }
    }
}
