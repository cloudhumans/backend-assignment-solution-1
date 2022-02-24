using CloudHumans.Assignment.Domain.ValueObjects.ProApplication;
using CloudHumans.Assignment.Domain.Aggregates;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;

namespace CloudHumans.Assignment.Domain.Tests.Aggregates
{
    [TestClass]
    public class PairingTests
    {
        private List<Project> GetSampleProjects()
        {
            return new List<Project> {
                new Project("calculate_dark_matter_nasa", 10),
                new Project("determine_schrodinger_cat_is_alive", 5),
                new Project("support_users_from_xyz", 3),
                new Project("collect_information_for_xpto", 2)};
        }

        [TestMethod]
        public void EnsureProWithScore7GetsTheProjectWithScore5GivenTheseConditions()
        {
            var proApplication = new ProApplication(
                Age.FromInteger(35),
                EducationLevel.FromString("high_school"),
                PastExperience.FromBooleans(false, true).ToList(),
                InternetTestResult.FromFloat(50.4f, 40.2f),
                WritingScore.FromFloat(0.6f),
                ReferralCode.CreateValid("token1234"));

            var pairing = Pairing.PerformPairing(proApplication, GetSampleProjects());

            Assert.AreEqual(5, pairing.SelectedProject.First().RequiredScore);
        }

        [TestMethod]
        public void EnsureProWithScore15GetsTheProjectWithScore10GivenTheseConditions()
        {
            var proApplication = new ProApplication(
                Age.FromInteger(35),
                EducationLevel.FromString("bachelors_degree_or_high"),
                PastExperience.FromBooleans(true, true).ToList(),
                InternetTestResult.FromFloat(50.4f, 50.2f),
                WritingScore.FromFloat(1f),
                ReferralCode.CreateValid("token1234"));

            var pairing = Pairing.PerformPairing(proApplication, GetSampleProjects());

            Assert.AreEqual(10, pairing.SelectedProject.First().RequiredScore);
        }

        [TestMethod]
        public void EnsureProWithScoreNegative3GetsNoProjectsGivenTheseConditions()
        {
            var proApplication = new ProApplication(
                Age.FromInteger(35),
                EducationLevel.FromString("no_education"),
                PastExperience.FromBooleans(false, false).ToList(),
                InternetTestResult.FromFloat(1.4f, 1.2f),
                WritingScore.FromFloat(0.0f),
                ReferralCode.CreateInvalid("token4321"));

            var pairing = Pairing.PerformPairing(proApplication, GetSampleProjects());

            Assert.IsTrue(pairing.SelectedProject.IsNone);
        }
    }
}