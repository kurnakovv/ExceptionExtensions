using System;
using System.Linq;
using System.Text;

namespace ExceptionExtensions
{
    public static class ExceptionExstension
    {
        public static string GetFullInfo(this Exception ex)
        {
            if (ex == null) return null;
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(new string('=', ex.Message.Length));
            if (ex.InnerException != null)
            {
                stringBuilder.AppendLine(ex.InnerException.GetFullInfo());
            }
            stringBuilder.AppendLine(ex.Message);
            stringBuilder.AppendLine(new string('=', ex.Message.Length));
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
