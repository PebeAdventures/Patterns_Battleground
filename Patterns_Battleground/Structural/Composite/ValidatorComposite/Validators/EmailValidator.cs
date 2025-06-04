using System.Text.RegularExpressions;
using Patterns_Battleground.Structural.Composite.ValidatorComposite.Abstractions;

namespace Patterns_Battleground.Structural.Composite.ValidatorComposite.Validators
{
    public class EmailValidator : IValidator
    {
        private static readonly Regex _emailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        public ValidatorResult Validate(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
                return ValidatorResult.Failure("email cannot be empty.");

            if (!_emailRegex.IsMatch(input))
            {
                return ValidatorResult.Failure("Invalid email format.");
            }

            return ValidatorResult.Success();
        }
    }
}
