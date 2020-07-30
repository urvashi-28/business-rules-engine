using Business.Rules.Engine.ProductAction;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Enigine.UnitTests.ProductAction
{
    [TestFixture]
    public class MembershipActionsShould
    {
        private IMembershipActions _membershipActions;

        [SetUp]
        public void Setup()
        {
            _membershipActions = new MembershipActions();
        }

        [Test]
        public void ActivateMembershipWhenActivateMembershipCalled()
        {
            var result = _membershipActions.ActivateMembership();

            result.Should().BeTrue();
        }

        [Test]
        public void UpgradeMembershipWhenUpgradeMembershipCalled()
        {
            var result = _membershipActions.UpgradeMembership();

            result.Should().BeTrue();
        }
    }
}
