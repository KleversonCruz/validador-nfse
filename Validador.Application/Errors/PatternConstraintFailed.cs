using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace Validador.Application.Errors
{
    public class PatternConstraintFailed : ValidationError
    {
        public PatternConstraintFailed(string message) : base(message) {
            SeverityType = XmlSeverityType.Error;
        }

        public const string Pattern = @"'(.+)'.*'(.+)'.*'(.+)'";

        public override string CreateValidationMessage()
        {
            Match match = new Regex(Pattern).Match(Message);
            return string.Format("O elemento '{0}' é inválido. O valor '{1}' não está de acordo com os tipos definidos em: {2}'", match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
        }
    }
}
