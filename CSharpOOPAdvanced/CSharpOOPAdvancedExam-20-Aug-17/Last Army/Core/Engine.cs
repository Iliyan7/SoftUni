using System;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private bool isRunning;
    private GameController gameController;

    public Engine(IReader reader, IWriter writer, GameController gameController)
    {
        this.reader = reader;
        this.writer = writer;
        this.isRunning = false;
        this.gameController = gameController;
    }

    public void Run()
    {
        this.isRunning = true;

        while (this.isRunning)
        {
            string input = this.reader.ReadLine();
            if (input == OutputMessages.InputTerminateString)
            {
                this.isRunning = false;
                continue;
            }

            try
            {
                gameController.ProcessCommand(input);
            }
            catch (ArgumentException arg)
            {
                this.writer.StoreMessage(arg.Message);
            }
        }

        this.gameController.ProduceSummury();
        this.writer.WriteLine(this.writer.StoredMessage.Trim());
    }
}

