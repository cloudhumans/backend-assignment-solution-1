using CloudHumans.Assignment.Domain.ValueObjects.ProApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CloudHumans.Assignment.Domain.Tests.ValueObjects
{
    [TestClass]
    public class PastExperienceTests
    {
        [TestMethod]
        public void Ensure5PointsAreGivenForSalesExperience()
        {
            var experience = PastExperience.FromBooleans(true, false);

            Assert.AreEqual(5, experience.First().Points);
        }

        [TestMethod]
        public void Ensure3PointsAreGivenForSupportExperience()
        {
            var experience = PastExperience.FromBooleans(false, true);

            Assert.AreEqual(3, experience.First().Points);
        }
    }
}