using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudHumans.Assignment.Domain.Aggregates;
using CloudHumans.Assignment.Domain.ValueObjects.ProApplication;
using System.Linq;

namespace CloudHumans.Assignment.Domain.Tests.Aggregates
{
    [TestClass]
    public class ProApplicationTests
    {
        [TestMethod]
        public void EnsureProEligibilityScoreIs7GivenTheseConditions()
        {
            var proApplication = new ProApplication(
                Age.FromInteger(35),
                EducationLevel.FromString("high_school"),
                PastExperience.FromBooleans(false, true).ToList(),
                InternetTestResult.FromFloat(50.4f, 40.2f),
                WritingScore.FromFloat(0.6f),
                ReferralCode.CreateValid("token1234"));

            Assert.AreEqual(7, proApplication.GetEligibilityScore());
        }

        [Ignore]
        [TestMethod]
        public void EnsureProEligibilityScoreIs15GivenTheseConditions()
        {
            var proApplication = new ProApplication(
               Age.FromInteger(35),
               EducationLevel.FromString("bachelors_degree_or_high"),
               PastExperience.FromBooleans(true, true).ToList(),
               InternetTestResult.FromFloat(50.4f, 50.2f),
               WritingScore.FromFloat(1f),
               ReferralCode.CreateValid("token1234"));

            Assert.AreEqual(15, proApplication.GetEligibilityScore());
        }


        [TestMethod]
        public void EnsureProEligibilityScoreIsNegative3GivenTheseConditions()
        {
            var proApplication = new ProApplication(
                Age.FromInteger(35),
                EducationLevel.FromString("no_education"),
                PastExperience.FromBooleans(false, false).ToList(),
                InternetTestResult.FromFloat(1.4f, 1.2f),
                WritingScore.FromFloat(0.0f),
                ReferralCode.CreateInvalid("token4321"));

            Assert.AreEqual(-3, proApplication.GetEligibilityScore());
        }
    }
}
