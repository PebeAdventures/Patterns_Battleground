using Patterns_Battleground.Structural.Flyweight.LogisticLabelsFlyweight.Core;

namespace Patterns_Battleground.Structural.Flyweight.LogisticLabelsFlyweight.Domain;

public class Package
{
    private readonly PackageContext _packageContext;
    private readonly List<ILabelFlyweight> _labels;

    public Package(PackageContext packageContext, List<ILabelFlyweight> labels)
    {
        ArgumentNullException.ThrowIfNull(packageContext, nameof(packageContext));
        ArgumentNullException.ThrowIfNull(labels, nameof(labels));

        _packageContext = packageContext;
        _labels = labels;
    }

    public void RenderLabels()
    {
        foreach (var label in _labels)
        {
            label.Render(_packageContext);
        }
    }
}
