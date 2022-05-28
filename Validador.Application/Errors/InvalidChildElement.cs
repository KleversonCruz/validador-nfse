using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace Validador.Application.Errors
{
    public class InvalidChildElement : ValidationError
    {
        public InvalidChildElement(string message) : base(message) {
            SeverityType = XmlSeverityType.Error;
        }

        public const string Pattern = @"element '(\w+)'.*element '(\w+)'.*expected: '(\w+)'";

        public override string CreateValidationMessage()
        {
            Match match = new Regex(Pattern).Match(Message);
            return string.Format("O elemento '{0}' possui elemento filho inválido: '{1}'. Era esperado o elemento: '{2}'", match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
        }
    }
}
