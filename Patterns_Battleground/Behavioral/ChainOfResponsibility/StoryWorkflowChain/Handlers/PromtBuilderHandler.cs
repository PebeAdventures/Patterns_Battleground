using Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Core;

namespace Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Handlers;

public class PromtBuilderHandler : StoryWorkflowHandler
{
    public override StoryContext Handle(StoryContext context)
    {
        if (context.IsBlocked)
            return context;

        var prompt = $"Create a {context.StoryType.ToLower()} in {context.Language} " +
                     $"for age group {context.AgeGroup}, with a {context.Tone.ToLower()} tone " +
                     $"and {context.Genre.ToLower()} theme.";
        context.Prompt = prompt ;
        return base.Handle(context);
    }
}
