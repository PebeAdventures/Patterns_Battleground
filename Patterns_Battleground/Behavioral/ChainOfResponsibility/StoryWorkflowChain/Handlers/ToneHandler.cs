using Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Core;

namespace Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Handlers
{
    public class ToneHandler : StoryWorkflowHandler
    {
        public override StoryContext Handle(StoryContext context)
        {
            context.Prompt += $"Tone: {context.Tone}";
            return base.Handle(context);
        }
    }
}
