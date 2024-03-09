using Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers.Connect;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers.File;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser.ArgumentHandlers.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser.CommandHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser;

public class CommandParser
{
    private readonly ICommandHandler _head = BuildCommandHandlerChain();

    public ParserOutput Parse(string command)
    {
        return _head.Handle(command);
    }

    private static ICommandHandler BuildCommandHandlerChain()
    {
        var head = new ConnectCommandHandler();
        head.SetArgumentHandler(BuildConnectArgumentHandlerChain())
            .SetNext(new FileCommandHandler())
            .SetArgumentHandler(BuildFileArgumentHandlerChain())
            .SetNext(new TreeCommandHandler())
            .SetArgumentHandler(BuildTreeArgumentHandlerChain())
            .SetNext(new DisconnectCommandHandler())
            .SetNext(new PrintWorkingDirectoryHandler())
            .SetNext(new UnknownCommandHandler());
        return head;
    }

    private static IArgumentHandler BuildConnectArgumentHandlerChain()
    {
        var head = new ConnectLocationHandler();
        head.SetNext(new ConnectStrategyHandler())
            .SetNext(new UnknownArgumentHandler());
        return head;
    }

    private static IArgumentHandler BuildFileArgumentHandlerChain()
    {
        var head = new FileCopyHandler();
        head.SetNext(new FileDeleteHandler())
            .SetNext(new FileMoveHandler())
            .SetNext(new FileRenameHandler())
            .SetNext(new FileShowHandler())
            .SetNext(new FileShowModeHandler())
            .SetNext(new UnknownArgumentHandler());
        return head;
    }

    private static IArgumentHandler BuildTreeArgumentHandlerChain()
    {
        var head = new TreeGoToHandler();
        head.SetNext(new TreeListDepthHandler())
            .SetNext(new TreeListLocationHandler())
            .SetNext(new UnknownArgumentHandler());
        return head;
    }
}