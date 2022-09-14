namespace StringProcessor.Commands;

using StringProcessor.IO;

public sealed class AlternateUpperLower : ICommand
{
    public string Description => "Converts the string to alternate upper and lower case and outputs it to stdout.";
    public string Title => "Alternate upper and lower";

    private readonly IConsoleOutput _consoleOutput;

    public AlternateUpperLower(IConsoleOutput consoleOutput)
    {
        _consoleOutput = consoleOutput;
    }

    public AlternateUpperLower()
    {
        _consoleOutput = new ConsoleOutput();
    }

    public void Run(string inputString)
    {
        var parts = inputString?.Split(' ') ?? new[] { "" };
        var result = string.Join(" ", parts.Select(ConvertWord));

        _consoleOutput.Print(result.Trim());
    }

    public string ConvertWord(string word)
    {
        if (string.IsNullOrEmpty(word)) return string.Empty;
        string result = string.Empty;
        for (int i = 0; i < word.Length; i++)
        {
            result += i % 2 == 0 ? char.ToLower(word[i]) : char.ToUpper(word[i]);
        }

        return result;
    }
}