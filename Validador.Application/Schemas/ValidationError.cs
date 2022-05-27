namespace Validador.Application.Schemas
{
    public class ValidationError
    {
        public enum Severity { Warning, Error }
        public ValidationError(string message, Severity severityType)
        {
            Message = message;
            SeverityType = severityType;
        }
        public string Message { get; set; }

        public Severity SeverityType { get; set; }
    }
}
