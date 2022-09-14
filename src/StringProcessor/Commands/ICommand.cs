namespace StringProcessor.Commands;

public interface ICommand
{
    string Description { get; }
    string Title { get; }
    void Run(string inputString);
}