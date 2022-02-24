using CloudHumans.Assignment.Domain.ValueObjects;
using CloudHumans.Assignment.Domain.ValueObjects.ProApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudHumans.Assignment.Domain.Tests.ValueObjects
{
    [TestClass]
    public class AgeTests
    {
        [TestMethod]
        public void EnsureProCantBeUnder18()
        {
            var error = AssertExtensions.Throws<BusinessException>(() => Age.FromInteger(17));

            Assert.AreEqual(1, error.Code);
        }
    }
}