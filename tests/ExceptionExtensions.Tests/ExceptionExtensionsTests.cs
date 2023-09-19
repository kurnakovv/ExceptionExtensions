using System;
using System.IO;
using System.Linq;
using System.Reflection;
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
        public void GetFullInfo_CanGetSource_ExceptionSource()
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
            Assert.Contains(ExceptionTextConstants.SOURCE_MESSAGE, message);
        }

        [Fact]
        public void GetFullInfo_CanGetFullAggregateExceptionInfo_AggregateExceptionInfo()
        {
            // Arrange.
            string message = null;
            object[] numbers = new object[] { 1, 2, 3, 4, 5, "6" };

            // Act
            var squares = from n in numbers.AsParallel()
                          let x = (int)n
                          select Square(x);
            try
            {
                squares.ForAll(n => Console.Write(n));
            }
            catch (AggregateException ex)
            {
                message = ex.GetFullInfo();
            }
            int Square(int n) => n * n;

            // Assert.
            Assert.NotNull(message);
            Assert.Contains(AggregateExceptionTextConstants.MAIN_SOURCE_MESSAGE, message);
#if NET5_0_OR_GREATER
            Assert.Contains(AggregateExceptionTextConstants.SUB_SOURCE_MESSAGE_NET5_0_OR_GREATER, message);
#endif
#if NETCOREAPP3_1
            Assert.Contains(AggregateExceptionTextConstants.SUB_SOURCE_MESSAGE_NETCOREAPP3_1, message);
#endif
            Assert.Contains(AggregateExceptionTextConstants.UNABLE_TO_CAST_OBJECT_OF_TYPE_STRING_TO_INT_MESSAGE, message);
#if NET5_0_OR_GREATER
            Assert.Contains(AggregateExceptionTextConstants.ONE_OR_MORE_ERRORS_OCCURRED_MESSAGE_NET5_0_OR_GREATER, message);
#endif
#if NETCOREAPP3_1
            Assert.Contains(AggregateExceptionTextConstants.ONE_OR_MORE_ERRORS_OCCURRED_MESSAGE_NETCOREAPP3_1, message);
#endif
        }

        [Fact]
        public void GetFullInfo_CanGetFileNameIfIsFileNotFoundException_FileName()
        {
            string message = null;
            try
            {
                Assembly.LoadFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + "InvalidFileName");
            }
            catch (Exception ex)
            {
                message = ex.GetFullInfo();
            }
            Assert.NotNull(message);
            Assert.Contains(FileNotFoundExceptionTextConstants.MESSAGE, message);
            Assert.Contains(FileNotFoundExceptionTextConstants.FILE_NAME_MESSAGE, message);
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
