using Patterns_Battleground.Structural.Composite.ValidatorComposite.Abstractions;

namespace Patterns_Battleground.Structural.Composite.ValidatorComposite.Validators
{
    public class NotContainsDigitValidator : IValidator
    {
        public ValidatorResult Validate(string input)
        {
            ArgumentNullException.ThrowIfNull(input);

            return input.Any(char.IsDigit)
                ? ValidatorResult.Failure("Input must not contain any digits.")
                : ValidatorResult.Success();
        }
    }
}
