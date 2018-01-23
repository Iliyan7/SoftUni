using System.Linq;

public class Engine : IEngine
{
    private bool isRunning;
    private readonly IReader reader;
    private readonly IWriter writer;
    private ICommandInterpreter commandInterpreter;

    public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.isRunning = false;
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        this.isRunning = true;

        while (isRunning)
        {
            var input = this.reader.ReadLine();

            var data = input.Split().ToList();
            var result = commandInterpreter.ProcessCommand(data);
            this.writer.WriteLine(result);

            if(result.StartsWith(Constants.SystemShutdown))
            {
                isRunning = false;
            }
        }
    }
}
