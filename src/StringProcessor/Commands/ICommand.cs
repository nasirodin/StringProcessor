namespace StringProcessor.Commands;

public interface ICommand
{
    public int Order { get; }
    string Description { get; }
    string Title { get; }
    void Run(string inputString);
}