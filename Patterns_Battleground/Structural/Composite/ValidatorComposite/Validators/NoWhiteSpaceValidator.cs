using Patterns_Battleground.Structural.Composite.ValidatorComposite.Abstractions;

namespace Patterns_Battleground.Structural.Composite.ValidatorComposite.Validators
{
    public class NoWhiteSpaceValidator : IValidator
    {
        public ValidatorResult Validate(string input)
        {
            ArgumentNullException.ThrowIfNull(input);

            return input.Any(char.IsWhiteSpace)
                ? ValidatorResult.Failure("Input must not contain any whitespace characters.")
                : ValidatorResult.Success();
        }
    }
}
