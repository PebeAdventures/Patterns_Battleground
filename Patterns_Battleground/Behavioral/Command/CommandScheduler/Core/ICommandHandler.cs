namespace Patterns_Battleground.Behavioral.Command.CommandScheduler.Core;

public interface ICommandHandler
{

    void Execute();

    void Undo();

}
