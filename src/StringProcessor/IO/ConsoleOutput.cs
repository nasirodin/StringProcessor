namespace StringProcessor.IO;

class ConsoleOutput : IConsoleOutput
{
    public void Print(string value)
    {
        Console.WriteLine(value);
    }
}