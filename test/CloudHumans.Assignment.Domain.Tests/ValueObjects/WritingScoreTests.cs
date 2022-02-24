using System;
using CloudHumans.Assignment.Domain.ValueObjects;
using CloudHumans.Assignment.Domain.ValueObjects.ProApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudHumans.Assignment.Domain.Tests.ValueObjects
{
    [TestClass]
    public class WritingScoreTests
    {
        [TestMethod]
        public void EnsureWritingScoreCantBeLessThanZero()
        {
            var error = AssertExtensions.Throws<BusinessException>(() => WritingScore.FromFloat(-1.0f));

            Assert.AreEqual(4, error.Code);
        }

        [TestMethod]
        public void EnsureWritingScoreCantBeMoreThanOne()
        {
            var error = AssertExtensions.Throws<BusinessException>(() => WritingScore.FromFloat(2.0f));

            Assert.AreEqual(4, error.Code);
        }

        [TestMethod]
        public void EnsureOnePointIsTakenIfWritingScoreIsLowerThan30Percent()
        {
            var writingScore = WritingScore.FromFloat(0.29f);

            Assert.AreEqual(-1, writingScore.Points);
        }

        [TestMethod]
        public void EnsureOnePointIsGivenIfWritingScoreIsBetween30And70Percent()
        {
            var writingScore = WritingScore.FromFloat(0.70f);

            Assert.AreEqual(1, writingScore.Points);
        }

        [TestMethod]
        public void EnsureTwoPointsAreGivenIfWritingScoreIsGreaterThan70Percent()
        {
            var writingScore = WritingScore.FromFloat(0.71f);

            Assert.AreEqual(2, writingScore.Points);
        }
    }
}