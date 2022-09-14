using FluentAssertions;
using StringProcessor.CLI;

namespace StringProcessor.Test;

public class CommandManagerTests
{
    [Fact]
    public void LoadCommandsTest()
    {
        var manager = new CommandManager();
        manager.Commands.Should().NotBeNull();
        manager.Commands.Should().HaveCount(3);
    }
}