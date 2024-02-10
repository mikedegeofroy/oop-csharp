using Itmo.ObjectOrientedProgramming.Lab1.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Router;

public record Path(IEnvironment Environment, long Length);