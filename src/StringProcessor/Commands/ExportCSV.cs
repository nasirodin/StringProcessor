namespace StringProcessor.Commands;

using StringProcessor.IO;

public sealed class ExportCsv : ICommand
{
    public string Description => "creates a CSV file from the string by making each character a column in the CSV";
    public string Title => "Export CSV";

    private readonly IConsoleOutput _consoleOutput;

    public ExportCsv(IConsoleOutput consoleOutput)
    {
        _consoleOutput = consoleOutput;
    }

    public ExportCsv()
    {
        _consoleOutput = new ConsoleOutput();
    }

    public void Run(string inputString)
    {
        throw new NotImplementedException();
    }
}