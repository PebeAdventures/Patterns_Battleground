namespace Patterns_Battleground.Behavioral.ChainOfResponsibility.StoryWorkflowChain.Core;

public abstract class StoryWorkflowHandler : IStoryWorkflowHandler
{
    private IStoryWorkflowHandler? _next;

    public virtual StoryContext Handle(StoryContext context)
    {
        if (context.IsBlocked)
            return context;

        return Next(context);
    }

    public IStoryWorkflowHandler SetNext(IStoryWorkflowHandler nextHandler)
    {
        _next = nextHandler;
        return this;
    }

    protected StoryContext Next(StoryContext context)
    => _next?.Handle(context) ?? context;

}
