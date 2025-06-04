using Patterns_Battleground.Structural.Composite.ValidatorComposite.Abstractions;

namespace Patterns_Battleground.Structural.Composite.ValidatorComposite.Validators
{
    public class ContainsDigitValidator : IValidator
    {
        public ValidatorResult Validate(string input)
        {
            ArgumentNullException.ThrowIfNull(input);

            return input.Any(char.IsDigit)
                ? ValidatorResult.Success()
                : ValidatorResult.Failure("Input must contain at least one digit.");
        }
    }
}
