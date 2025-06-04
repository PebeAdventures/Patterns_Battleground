using Patterns_Battleground.Structural.Composite.ValidatorComposite.Abstractions;

namespace Patterns_Battleground.Structural.Composite.ValidatorComposite.Validators
{
    public class MinLengthValidator : IValidator
    {
        private readonly int _minLength;

        public MinLengthValidator(int minLength)
        {
            if (minLength < 0)
                throw new ArgumentOutOfRangeException(nameof(minLength), "Min length must be non-negative");

            _minLength = minLength;
        }

        public ValidatorResult Validate(string input)
        {
            if(input == null)
                throw new ArgumentNullException(nameof(input), "Input cannot be null");

            return input.Length >= _minLength
                ? ValidatorResult.Success()
                : ValidatorResult.Failure($"Input must be at least {_minLength} characters long. Current length: {input.Length}.");
        }
    }
}
