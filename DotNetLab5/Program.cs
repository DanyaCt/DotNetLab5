using DotNetLab5.Contexts;
using DotNetLab5.Handlers;
using DotNetLab5.IO;
using DotNetLab5.Loggers;
using DotNetLab5.Services;

var context = new TransactionsContext();

var authorizationService = new AuthorizationService(context);
var authorizationHandler = new AuthorizationHandler(authorizationService);

var commissionService = new CommissionService(context);
var commissionHandler = new CommissionHandler(commissionService);

var logger = new ConsoleLogger();
var loggerHandler = new LogHandler(logger);

authorizationHandler.SetNext(commissionHandler);
commissionHandler.SetNext(loggerHandler);

var transactionService = new TransactionService(authorizationHandler);
var menu = new MenuService(context);

while (true)
{
    Console.Clear();
    try
    {
        var sender = menu.ChooseSender();
        Console.WriteLine();

        var receiver = menu.ChooseReceiver(sender);
        Console.WriteLine();

        var amount = menu.GetAmountOfMoney(sender);
        Console.WriteLine();

        var transactionType = menu.ChooseTransactionType();

        Console.WriteLine("\nPress any key to run transaction:");
        Console.ReadKey();

        var result = transactionService.PerformTransaction(sender, receiver, amount, transactionType);
        Console.WriteLine(result);

        Console.WriteLine("\nDo you want to continue? (press '1' if yes)");
        var key = Console.ReadKey().KeyChar;
        if (key != '1')
            break;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        Console.ReadKey();
    }
}