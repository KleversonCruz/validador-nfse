using System.Xml.Schema;

namespace Validador.Application.Errors
{
    public class GenericValidationError : ValidationError
    {
        public GenericValidationError(string message) : base(message)
        {
            SeverityType = XmlSeverityType.Warning;
        }

        public override string CreateValidationMessage()
        {
            return string.Format("Erro de validação: '{0}'", Message);
        }
    }
}
