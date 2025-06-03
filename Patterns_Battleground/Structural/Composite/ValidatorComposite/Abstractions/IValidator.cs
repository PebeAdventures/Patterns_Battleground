namespace Patterns_Battleground.Structural.Composite.ValidatorComposite.Abstractions
{
    public interface IValidator
    {
        ValidationResult Validate(string input);
    }
}
