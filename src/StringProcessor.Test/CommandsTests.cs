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
    public void AlternateUpperLowerTest(string input, string output)
    {
        var mockConsoleOutput = new Mock<IConsoleOutput>();

        var command = new Commands.AlternateUpperLower(mockConsoleOutput.Object);
        command.Run(input);

        mockConsoleOutput.Verify(t => t.Print(output), Times.Once);
    }

    [Theory]
    [InlineData("hello world", new string[] { "h", "e", "l", "l", "o", " ", "w", "o", "r", "l", "d" })]
    [InlineData("hElLo wOrLd", new[] { "h", "e", "l", "l", "o", " ", "w", "o", "r", "l", "d" })]
    [InlineData("HELLO WORLD", new[] { "h", "e", "l", "l", "o", " ", "w", "o", "r", "l", "d" })]
    [InlineData("", new string[0])]
    [InlineData(null, new string[0])]
    public void CreateCsvTest(string input, string[] data)
    {
        var mockConsoleOutput = new Mock<IConsoleOutput>();
        var mockCsvOutput = new Mock<ICsvOutput>();

        var command = new Commands.ExportCsv(mockConsoleOutput.Object, mockCsvOutput.Object);
        command.Run(input);

        mockConsoleOutput.Verify(t => t.Print("CSV created!"), Times.Once);
        mockCsvOutput.Verify(t => t.WriteToCsv(It.Is<IEnumerable<string>>(p => p.SequenceEqual(data))));
    }
}