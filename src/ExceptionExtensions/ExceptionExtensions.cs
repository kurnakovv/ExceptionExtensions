using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ExceptionExtensions
{
    /// <summary>
    /// <seealso cref="ExceptionExstension"/> is a class with useful methods for working with exceptions.
    /// </summary>
    public static class ExceptionExstension
    {
        /// <summary>
        /// Get full exception info.
        /// </summary>
        /// <remarks>If <paramref name="ex"/> is null, method return null.</remarks>
        /// <param name="ex">Exception with full info.</param>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <returns>Message + Type + InnerException + StackTrace</returns>
        public static string GetFullInfo(this Exception ex)
        {
            if (ex == null) return null;
            var stringBuilder = new StringBuilder();
            string source = $"Source: {ex.Source ?? "-- No source --"}";
            stringBuilder.AppendLine(source);
            stringBuilder.AppendLine(new string('#', source.Length));
            if (ex is AggregateException aggregateException &&
                aggregateException.InnerExceptions != null &&
                aggregateException.InnerExceptions.Count > 0)
            {
                foreach (Exception item in aggregateException.InnerExceptions)
                {
                    stringBuilder.AppendLine(item.GetFullInfo());
                }
            }
            else if (ex.InnerException != null)
            {
                stringBuilder.AppendLine(ex.InnerException.GetFullInfo());
            }
            stringBuilder.AppendLine(ex.Message);
            stringBuilder.AppendLine(new string('=', ex.Message.Length));
            string exceptionType = $"Type: \"{ex.GetType()}\"";
            stringBuilder.AppendLine(exceptionType);
            stringBuilder.AppendLine(new string('*', exceptionType.Length));
            if (ex is FileNotFoundException fileNotFoundException)
            {
                string fileName = $"File name: \"{fileNotFoundException.FileName}\"";
                stringBuilder.AppendLine(fileName);
                stringBuilder.AppendLine(new string('+', fileName.Length));
            }
            if (ex.StackTrace != null)
            {
                int stackTraceMaxLineLength = ex.StackTrace
                    .Split(new char[] { '\r', '\n' })
                    .Select(x => x.Length)
                    .Max();
                stringBuilder.AppendLine(new string('-', stackTraceMaxLineLength));
                stringBuilder.AppendLine(ex.StackTrace);
                stringBuilder.AppendLine(new string('-', stackTraceMaxLineLength));
            }
            return stringBuilder.ToString();
        }
    }
}
