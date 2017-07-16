using System;
using System.Collections.Generic;
using System.Linq;

class Engine
{
    private DraftManager manager;
    private bool isRun;

    public Engine()
    {
        this.manager = new DraftManager();
        this.isRun = true;
    }

    public void Run()
    {
        while (this.isRun)
        {
            var commandArguments = Console.ReadLine().Split(' ').ToList();
            this.Execute(commandArguments);
        }
    }

    private void Execute(List<string> commandArguments)
    {
        var command = commandArguments.First();
        commandArguments.RemoveAt(0);

        switch (command)
        {
            case "RegisterHarvester":
                {
                    var output = this.manager.RegisterHarvester(commandArguments);
                    Console.WriteLine(output);
                    break;
                }
            case "RegisterProvider":
                {
                    var output = this.manager.RegisterProvider(commandArguments);
                    Console.WriteLine(output);
                    break;
                }
            case "Day":
                {
                    var output = this.manager.Day();
                    Console.WriteLine(output);
                    break;
                }
            case "Mode":
                {
                    var output = this.manager.Mode(commandArguments);
                    Console.WriteLine(output);
                    break;
                }
            case "Check":
                {
                    var output = this.manager.Check(commandArguments);
                    Console.WriteLine(output);
                    break;
                }
            case "Shutdown":
                {
                    var output = this.manager.ShutDown();
                    Console.WriteLine(output);
                    this.isRun = false;
                    break;
                }
        }
    }
}