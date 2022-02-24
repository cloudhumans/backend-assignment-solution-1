using CloudHumans.Assignment.Domain.ValueObjects.ProApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudHumans.Assignment.Domain.Tests.ValueObjects
{
    [TestClass]
    public class ReferralCodeTests
    {
        [TestMethod]
        public void EnsureValidReferralCodeGivesOnePoint()
        {
            Assert.AreEqual(1, ReferralCode.CreateValid("token1234").Points);
        }

        [TestMethod]
        public void EnsureInvalidReferralCodeGivesNoPoints()
        {
            Assert.AreEqual(0, ReferralCode.CreateInvalid("token1234").Points);
        }
    }
}