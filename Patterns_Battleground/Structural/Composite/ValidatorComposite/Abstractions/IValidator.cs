namespace Patterns_Battleground.Structural.Composite.ValidatorComposite.Abstractions
{
    public interface IValidator
    {
        ValidatorResult Validate(string input);
    }
}
