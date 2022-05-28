using System.Xml.Schema;

namespace Validador.Application.Errors
{
    public abstract class ValidationError : Exception
    {
        public ValidationError(string message) : base(message)
        {
        }
        public string ValidationMessage
        {
            get
            {
                return CreateValidationMessage();
            }
        }

        public abstract string CreateValidationMessage();
        public XmlSeverityType SeverityType { get; set; }
    }
}

