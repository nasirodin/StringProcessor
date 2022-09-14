using System.Collections.ObjectModel;
using StringProcessor.Commands;

namespace StringProcessor.CLI;

public sealed class CommandManager
{
    private readonly IList<ICommand> _commands;
    public IReadOnlyList<ICommand> Commands => new ReadOnlyCollection<ICommand>(_commands);
    public CommandManager()
    {
        var commandTypes = this.GetType().Assembly.GetTypes()
            .Where(t => typeof(ICommand).IsAssignableFrom(t) && t.IsInterface == false)
            .ToList();
        _commands = commandTypes.Select(t => Activator.CreateInstance(t)).Cast<ICommand>().ToList();
    }

    public void Run()
    {
        Console.WriteLine("Please enter a string to process:");
        var input = Console.ReadLine();
        foreach (var command in _commands)
        {
            command.Run(input);
        }
    }
}