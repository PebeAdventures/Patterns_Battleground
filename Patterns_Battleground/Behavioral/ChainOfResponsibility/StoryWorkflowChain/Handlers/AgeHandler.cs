using Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Core;

namespace Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Handlers
{
    public class AgeHandler : StoryWorkflowHandler
    {
        public override StoryContext Handle(StoryContext context)
        {
            context.Prompt += $"Target age: {context.AgeGroup}";
            return base.Handle(context);
        }
    }
}
