using CloudHumans.Assignment.Domain.ValueObjects;
using CloudHumans.Assignment.Domain.ValueObjects.ProApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudHumans.Assignment.Domain.Tests.ValueObjects
{
    [TestClass]
    public class EducationLevelTests
    {        
        [TestMethod]
        public void EnsureUndefinedProEducationLevelThrowsError()
        {
            var error = AssertExtensions.Throws<BusinessException>(() => EducationLevel.FromString("doest_not_exist"));

            Assert.AreEqual(2, error.Code);
        }

        [TestMethod]
        public void EnsureZeroPointsAreGivenForProWithEducationLevelNoEducation()
        {
            var educationLevel = EducationLevel.FromString("no_education");

            Assert.AreEqual(0, educationLevel.Points);
        }

        [TestMethod]
        public void EnsureOnePointIsGivenForProWithEducationLevelHighSchool()
        {
            var educationLevel = EducationLevel.FromString("high_school");

            Assert.AreEqual(1, educationLevel.Points);
        }

        [Ignore]
        [TestMethod]
        public void EnsureTwoPointsAreGivenForProEducationLevelBachelorsDegreeOrHigher()
        {
            var educationLevel = EducationLevel.FromString("bachelors_degree_or_high");

            Assert.AreEqual(2, educationLevel.Points);
        }
    }
}