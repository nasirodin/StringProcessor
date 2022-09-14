namespace StringProcessor.Test;

using StringProcessor.Commands;
using StringProcessor.IO;
using Moq;
using FluentAssertions;

public class CommandsTests
{
    [Theory]
    [InlineData("hello world", "HELLO WORLD")]
    [InlineData(null, "")]
    [InlineData(" ", "")]
    [InlineData("hello 123", "HELLO 123")]
    [InlineData("HELLO WORLD", "HELLO WORLD")]
    [InlineData("hElLo wOrLd", "HELLO WORLD")]
    public void ToUpperCommandTest(string input, string output)
    {
        var mockConsoleOutput = new Mock<IConsoleOutput>();

        var command = new Commands.ConvertToUpperCase(mockConsoleOutput.Object);
        command.Run(input);

        mockConsoleOutput.Verify(t => t.Print(output), Times.Once);
    }

    [Theory]
    [InlineData("hello world", "hElLo wOrLd")]
    [InlineData("HELLO WORLD", "hElLo wOrLd")]
    [InlineData(null, "")]
    [InlineData(" ", "")]
    [InlineData("hello 123", "hElLo 123")]
    [InlineData("1@#23", "1@#23")]
    [InlineData("hElLo wOrLd", "hElLo wOrLd")]
    public void AlternateUpperLower(string input, string output)
    {
        var mockConsoleOutput = new Mock<IConsoleOutput>();

        var command = new Commands.AlternateUpperLower(mockConsoleOutput.Object);
        command.Run(input);

        mockConsoleOutput.Verify(t => t.Print(output), Times.Once);
    }
}