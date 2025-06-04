using Patterns_Battleground.Structural.Composite.ValidatorComposite.Abstractions;

namespace Patterns_Battleground.Structural.Composite.ValidatorComposite.Composites;

public class OrValidator : IValidator
{
    private readonly List<IValidator> _validators = [];

    public void Add(IValidator validator)
    {
        ArgumentNullException.ThrowIfNull(validator);

        _validators.Add(validator);
    }

    public void AddMany(IEnumerable<IValidator> validators)
    {
        ArgumentNullException.ThrowIfNull(validators);

        foreach (var validator in validators)
        {
            Add(validator);
        }
    }

    // Returns success if at least one validator passes.
    // Otherwise, returns combined failure message from all.
    public ValidatorResult Validate(string input)
    {
        List<ValidatorResult> failedResults = [];

        foreach (var validator in _validators)
        {
            var result = validator.Validate(input);
            if (result.IsValid)
            {
                return ValidatorResult.Success();
            }
            else
            {
                failedResults.Add(result);
            }
        }
        var incorrectMessages = string.Join("; ", failedResults.Select(m => m.ErrorMessage));
        return ValidatorResult.Failure(incorrectMessages);
    }
}
