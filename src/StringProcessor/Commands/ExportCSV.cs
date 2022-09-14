namespace StringProcessor.Commands;

using StringProcessor.IO;

public sealed class ExportCsv : ICommand
{
    public string Description => "creates a CSV file from the string by making each character a column in the CSV";
    public string Title => "Export CSV";
    public int Order => 3;
    private readonly IConsoleOutput _consoleOutput;
    private readonly ICsvOutput _csvOutput;
    public ExportCsv(IConsoleOutput consoleOutput, ICsvOutput csvOutput)
    {
        _consoleOutput = consoleOutput;
        _csvOutput = csvOutput;
    }

    public ExportCsv()
    {
        _csvOutput = new CsvOutput();
        _consoleOutput = new ConsoleOutput();
    }

    public void Run(string inputString)
    {
        var data = inputString?.ToLower().Select(c => c.ToString()).ToList() ?? new List<string>();
        _csvOutput.WriteToCsv(data);
        _consoleOutput.Print("CSV created!");
    }
}