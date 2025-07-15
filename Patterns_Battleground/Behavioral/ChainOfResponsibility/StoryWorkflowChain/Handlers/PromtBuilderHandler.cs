using Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Core;

namespace Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Handlers;

public class PromtBuilderHandler : StoryWorkflowHandler
{
    public override StoryContext Handle(StoryContext context)
    {
        if (context.IsBlocked)
            return context;


        var segments = new List<string>();

        if (!string.IsNullOrWhiteSpace(context.StoryType))
            segments.Add($"a {context.StoryType.ToLower()}");

        if (!string.IsNullOrWhiteSpace(context.Language))
            segments.Add($"in {context.Language}");

        if (!string.IsNullOrWhiteSpace(context.AgeGroup))
            segments.Add($"for age group {context.AgeGroup}");

        if (!string.IsNullOrWhiteSpace(context.Tone))
            segments.Add($"with a {context.Tone.ToLower()} tone");

        if (!string.IsNullOrWhiteSpace(context.Genre))
            segments.Add($"and {context.Genre.ToLower()} theme");

        var prompt = "Create " + string.Join(", ", segments) + ".";

        context.Prompt = prompt ;
        return base.Handle(context);
    }
}
