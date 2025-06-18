using System.Collections.Concurrent;

namespace Patterns_Battleground.Structural.Flyweight.LogisticLabelsFlyweight.Core;
public record LabelKey(string Name, string Icon, string Color);
public class LabelFlyweightFactory
{
    private readonly object _lock = new();
    private readonly ConcurrentDictionary<LabelKey, ILabelFlyweight> _flyweights = [];

    public ILabelFlyweight GetLabel(string name, string icon, string color)
    {
        var key = new LabelKey(name, icon, color);
        return _flyweights.GetOrAdd(key, _ => new LabelFlyweight(name, icon, color));
    }
}


//  Use a lock block instead of GetOrAdd if you need finer control over the creation logic.   
/*    
private readonly object _lock = new();
private readonly Dictionary<LabelKey, ILabelFlyweight> _flyweights = [];

    public ILabelFlyweight GetLabel(string name, string icon, string color)
    {
        var key = new LabelKey(name, icon, color);
        lock (_lock)
        {
            if (_flyweights.TryGetValue(key, out var existing))
            {
                return existing;
            }

            var newFlyweight = new LabelFlyweight(name, icon, color);
            _flyweights.Add(key, newFlyweight);
            return newFlyweight;
        }

    }*/