using System.Text.RegularExpressions;

namespace Validador.Application
{
    public static class ErrorHandler
    {
        public static string GetMessage(string error)
        {
            if (new Regex(ValidationErrors.InvalidChildElement).IsMatch(error))
            {
                Match match = new Regex(ValidationErrors.InvalidChildElement).Match(error);
                return string.Format("O elemento '{0}' possui filho '{1}' inválido. Era esperado elemento: '{2}'", match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);

            }
            else if (new Regex(ValidationErrors.InvalidElementPattern).IsMatch(error))
            {
                Match match = new Regex(ValidationErrors.InvalidElementPattern).Match(error);
                return string.Format("O elemento '{0}' é inválido. O valor '{1}' não está de acordo com os tipos definidos em: {2}'", match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
            }
            else if (new Regex(ValidationErrors.AttributeMissing).IsMatch(error))
            {
                Match match = new Regex(ValidationErrors.AttributeMissing).Match(error);
                return string.Format("O atributo obrigatório '{0}' está faltando", match.Groups[1].Value);
            }
            else
            {
                return error;
            }
        }
    }

    public class ValidationErrors
    {
        public const string InvalidChildElement = @".*The element '(\w+)'.*has invalid child element '(\w+)'.*List of possible elements expected: '(\w+)'.*";
        public const string InvalidElementPattern = @".*The '.*:(\w+)'.*element is invalid.*The value '(\w+\W)'.*to its datatype '.*:(\w+)'.*";
        public const string AttributeMissing = @".*The required attribute '(\w+)' is missing.*";
    }
}
