using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validador.Application.Errors
{
    public static class ErrorFactory
    {
        public static ValidationError Create(string errorMessage)
        {
            switch (errorMessage)
            {
                default:
                    return new GenericValidationError(errorMessage);
                case var messagem when new Regex(@"The Pattern constraint failed").IsMatch(messagem):
                    return new PatternConstraintFailed(errorMessage);
                case var messagem when new Regex(@"List of possible elements expected").IsMatch(messagem):
                    return new InvalidChildElement(errorMessage);
            }
        }
    }


}