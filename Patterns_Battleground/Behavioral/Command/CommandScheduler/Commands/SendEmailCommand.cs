using Patterns_Battleground.Behavioral.Command.CommandScheduler.Core;
using Patterns_Battleground.Behavioral.Command.CommandScheduler.Model;

namespace Patterns_Battleground.Behavioral.Command.CommandScheduler.Commands;

public class SendEmailCommand : ICommandHandler
{

    private readonly UserContactData userContactData;
    private readonly UserMessage userMessage;

    public SendEmailCommand(UserContactData userContactData, UserMessage userMessage)
    {
        this.userContactData = userContactData;
        this.userMessage = userMessage;
    }


    public void Execute()
    {
        throw new NotImplementedException();
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }
}
