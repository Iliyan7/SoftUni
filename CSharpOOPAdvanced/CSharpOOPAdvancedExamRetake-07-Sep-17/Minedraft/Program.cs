public class Program
{
    public static void Main(string[] args)
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        ICommandInterpreter commandInterpreter = new CommandInterpreter();
        Engine engine = new Engine(reader, writer, commandInterpreter);

        engine.Run();
    }
}