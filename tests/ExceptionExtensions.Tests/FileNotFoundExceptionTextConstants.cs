namespace ExceptionExtensions.Tests
{
    public class FileNotFoundExceptionTextConstants
    {
        public const string MESSAGE = @"Could not load file or assembly 'C:\InvalidFileName'. The system cannot find the file specified.
================================================================================================";
        public const string FILE_NAME_MESSAGE = @"File name: " + "\"" + @"C:\InvalidFileName" + "\"" + @"
+++++++++++++++++++++++++++++++";
    }
}
