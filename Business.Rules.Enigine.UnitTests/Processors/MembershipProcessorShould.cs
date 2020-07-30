using Business.Rules.Engine.Processors;
using Business.Rules.Engine.ProductAction;
using Moq;
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
        private Mock<IMembershipActions> _mockMembershipActions;

        [SetUp]
        public void Setup()
        {
            _mockMembershipActions = new Mock<IMembershipActions>();
            _membershipProcessor = new MembershipProcessor(_mockMembershipActions.Object);
        }

        [Test]
        public void ProcessActivateMembershipWhenActivateMembershipCalledAndMembershipActionReturendTrue()
        {
            _mockMembershipActions.Setup(m => m.ActivateMembership()).Returns(true);

            _membershipProcessor.ActivateMembership();

            _mockMembershipActions.Verify(m => m.ActivateMembership(), Times.Once);
        }

        [Test]
        public void ProcessUpgradeMembershipWhenUpgradeMembershipCalledAndMembershipActionReturendTrue()
        {
            _mockMembershipActions.Setup(m => m.UpgradeMembership()).Returns(true);

            _membershipProcessor.UpgradeMembership();

            _mockMembershipActions.Verify(m => m.UpgradeMembership(), Times.Once);
        }

        [Test]
        public void ThrowTimeoutExceptionIfMembershipActionThrowsTimeoutExceptionWhenActivateMembershipCalled()
        {
            _mockMembershipActions.Setup(m => m.ActivateMembership()).Throws<TimeoutException>();

            Assert.Throws<TimeoutException>(() => _membershipProcessor.ActivateMembership());

            _mockMembershipActions.Verify(m => m.ActivateMembership(), Times.Once);
        }

        [Test]
        public void ThrowTimeoutExceptionIfMembershipActionThrowsTimeoutExceptionWhenUpgradeCalled()
        {
            _mockMembershipActions.Setup(m => m.UpgradeMembership()).Throws<TimeoutException>();

            Assert.Throws<TimeoutException>(() => _membershipProcessor.UpgradeMembership());

            _mockMembershipActions.Verify(m => m.UpgradeMembership(), Times.Once);
        }
    }
}
