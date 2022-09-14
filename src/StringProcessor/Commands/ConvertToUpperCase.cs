namespace StringProcessor.Commands;

using StringProcessor.IO;

public sealed class ConvertToUpperCase : ICommand
{
    public string Description => "Converts the string to uppercase and outputs it to stdout.";
    public string Title => "Converts to Uppercase";
    public int Order => 1;
    private readonly IConsoleOutput _consoleOutput;

    public ConvertToUpperCase(IConsoleOutput consoleOutput)
    {
        _consoleOutput = consoleOutput;
    }

    public ConvertToUpperCase()
    {
        _consoleOutput = new ConsoleOutput();
    }

    public void Run(string inputString)
    {
        _consoleOutput.Print(inputString?.Trim().ToUpper() ?? string.Empty);
    }
}