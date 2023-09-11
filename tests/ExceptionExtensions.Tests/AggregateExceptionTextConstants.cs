namespace ExceptionExtensions.Tests
{
    public class AggregateExceptionTextConstants
    {
        public const string MAIN_SOURCE_MESSAGE = @"Source: System.Linq.Parallel
############################";

        public const string SUB_SOURCE_MESSAGE_NET5_0_OR_GREATER = @"Source: System.Private.CoreLib
##############################";

        public const string SUB_SOURCE_MESSAGE_NETCOREAPP3_1 = @"Source: ExceptionExtensions.Tests
#################################";

        public const string UNABLE_TO_CAST_OBJECT_OF_TYPE_STRING_TO_INT_MESSAGE = @"Unable to cast object of type 'System.String' to type 'System.Int32'.
=====================================================================";

        public const string ONE_OR_MORE_ERRORS_OCCURRED_MESSAGE_NET5_0_OR_GREATER = @"One or more errors occurred. (Unable to cast object of type 'System.String' to type 'System.Int32'.)
====================================================================================================";

        public const string ONE_OR_MORE_ERRORS_OCCURRED_MESSAGE_NETCOREAPP3_1 = @"One or more errors occurred. (One or more errors occurred. (Unable to cast object of type 'System.String' to type 'System.Int32'.)) (Unable to cast object of type 'System.String' to type 'System.Int32'.)
===========================================================================================================================================================================================================";
    }
}
