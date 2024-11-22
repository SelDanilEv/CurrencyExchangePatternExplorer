using CurrencyExchangePatternExplorer.Commands;
using CurrencyExchangePatternExplorer.Model;

var command = "start";

var model = new CurrencyExchangeModel();

while (command != "end")
{
    Console.WriteLine("Write command");
    command = Console.ReadLine();

    try
    {
        switch (command.ToLower())
        {
            case "start":
                UploadFileCommand.Run(model, true);
                break;
            case "import":
                UploadFileCommand.Run(model);
                break;
            case "calc":
                model.RunAll();
                break;
            case "print":
                model.PrintAll();
                break;
            case "all":
                UploadFileCommand.Run(model, true);
                model.RunAll();
                model.PrintAll();
                break;
            default:
                Console.WriteLine("Invalid command");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Something goes wrong");
    }

}

