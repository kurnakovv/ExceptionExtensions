using System;
using Xunit;

namespace ExceptionExtensions.Tests
{
    public class ExceptionExtensionsTests
    {
        [Fact]
        public void GetFullInfo_CanGetFullExceptionInfo_FullException()
        {
            // Arrange.
            string message = null;

            // Act
            try
            {
                string[] array = new string[4] { "1", "2", "3", "4" };
                int invalidElement = array[5].Length;
            }
            catch (Exception ex)
            {
                message = ex.GetFullInfo();
            }

            // Assert.
            Assert.NotNull(message);
            Assert.Contains(ExceptionTextConstants.INDEX_WAS_OUTSIDE_THE_BOUNDS_OF_THE_ARRAY_MESSAGE, message);
        }

        [Fact]
        public void GetFullInfo_CannotGetFullInfoIfExceptionIsNull_Null()
        {
            // Arrange.
            Exception exception = null;

            // Act.
            string result = exception?.GetFullInfo();

            // Assert.
            Assert.Null(result);
        }
    }
}
