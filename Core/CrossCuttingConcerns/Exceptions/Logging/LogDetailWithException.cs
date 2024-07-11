namespace Core.CrossCuttingConcerns.Exceptions.Logging
{
    public class LogDetailWithException : LogDetail
    {
        public string ExceptionMessage { get; set; }
    }
}
