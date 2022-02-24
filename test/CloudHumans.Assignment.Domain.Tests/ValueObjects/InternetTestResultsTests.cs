using CloudHumans.Assignment.Domain.ValueObjects;
using CloudHumans.Assignment.Domain.ValueObjects.ProApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudHumans.Assignment.Domain.Tests.ValueObjects
{
    [TestClass]
    public class InternetTestResultsTests
    {
        [TestMethod]
        public void EnsureInternetTestDownloadCantBeLessThanZero()
        {
            var error = AssertExtensions.Throws<BusinessException>(() => InternetTestResult.FromFloat(-1.0f, 1.0f));

            Assert.AreEqual(3, error.Code);
        }

        [TestMethod]
        public void EnsureInternetTestUploadCantBeLessThanZero()
        {
            var error = AssertExtensions.Throws<BusinessException>(() => InternetTestResult.FromFloat(1.0f, -1.0f));

            Assert.AreEqual(3, error.Code);
        }

        [TestMethod]
        public void EnsureLessThan5MBUploadAndDownloadDecreasesTwoPoints()
        {
            var testResults = InternetTestResult.FromFloat(4.0f, 4.0f);

            Assert.AreEqual(-2, testResults.Points);
        }

        [TestMethod]
        public void EnsureMoreThan50MBUploadAndDownloadIncreasesTwoPoints()
        {
            var testResults = InternetTestResult.FromFloat(55.0f, 55.0f);

            Assert.AreEqual(2, testResults.Points);
        }

        [TestMethod]
        public void EnsureNoPointsAreGivenIfUploadIsFastAndDownloadIsSlow()
        {
            var testResults = InternetTestResult.FromFloat(3.0f, 55.0f);

            Assert.AreEqual(0, testResults.Points);
        }

        [TestMethod]
        public void EnsureNoPointsAreGivenIfDownloadIsFastAndUploadIsSlow()
        {
            var testResults = InternetTestResult.FromFloat(53.0f, 3.0f);

            Assert.AreEqual(0, testResults.Points);
        }
    }
}