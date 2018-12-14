namespace Agero.Core.ApiInfo.Tests.Helpers
{
    public static class ConstantHelper
    {
        public const string ApplicationName = "TestApplicaton";
        public const string ApplicationVersion = "1.0.0.0";
        public static readonly object CustomerApplicationInformation = new {
            customApplicationDescription = "Application description specific to the application",
            customerApplicationInfo = "Application Info specific to the application"
        };
    }
}