using System.Text.RegularExpressions;
using Patterns_Battleground.Structural.Composite.ValidatorComposite.Abstractions;

namespace Patterns_Battleground.Structural.Composite.ValidatorComposite.Composites
{
    public class EmailValidator : IValidator
    {
        private static readonly Regex _emailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        public ValidationResult Validate(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
                return ValidationResult.Failure("email cannot be empty.");

            if (!_emailRegex.IsMatch(input))
            {
                return ValidationResult.Failure("Invalid email format.");
            }

            return ValidationResult.Success();
        }
    }
}
