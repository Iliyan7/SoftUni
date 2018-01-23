using System;
using System.Linq;

//namespace CSharpOOPBasicsExam_16_July_2017
//{
public class Engine
{
    private DraftManager manager;
    private bool isRunning;

    public Engine()
    {
        this.manager = new DraftManager();
        this.isRunning = true;
    }

    public void Run()
    {
        while (isRunning)
        {
            var inputArgs = Console.ReadLine()
                .Split(' ')
                .ToList();

            var command = inputArgs[0];
            inputArgs.RemoveAt(0);

            switch (command)
            {
                case "RegisterHarvester":
                    {
                        Console.WriteLine(manager.RegisterHarvester(inputArgs));
                        break;
                    }
                case "RegisterProvider":
                    {
                        Console.WriteLine(manager.RegisterProvider(inputArgs));
                        break;
                    }
                case "Day":
                    {
                        Console.WriteLine(manager.Day());
                        break;
                    }
                case "Mode":
                    {
                        Console.WriteLine(manager.Mode(inputArgs));
                        break;
                    }
                case "Check":
                    {
                        Console.WriteLine(manager.Check(inputArgs));
                        break;
                    }
                case "Shutdown":
                    {
                        Console.WriteLine(manager.ShutDown());
                        isRunning = false;
                        break;
                    }
            }
        }
    }
}
//}
