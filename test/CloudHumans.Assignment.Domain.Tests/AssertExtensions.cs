using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudHumans.Assignment.Domain.Tests
{
    public static class AssertExtensions
    {
        public static TException Throws<TException>(Action action) where TException : Exception
        {
            try
            {
                action();
                Assert.Fail("Exception not thrown.");
                return null;
            }
            catch (TException ex)
            {
                return ex;
            }
        }
    }
}