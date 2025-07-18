﻿using Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Core;

namespace Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Handlers
{
    public class StoryTypeHandler : StoryWorkflowHandler
    {
        public override StoryContext Handle(StoryContext context)
        {
            if (context.StoryType == "Book" && !context.IsPremiumUser) 
            {
                context.Block("Generating books is available only for premium users.");
                return context;
            }

            context.Prompt += $"Story type: {context.StoryType}";
            return base.Handle(context);
        }
    }
}
