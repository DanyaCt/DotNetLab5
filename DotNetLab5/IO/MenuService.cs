using DotNetLab5.Contexts;
using DotNetLab5.Entities;

namespace DotNetLab5.IO
{
    internal class MenuService
    {
        private readonly TransactionsContext _context;
        public MenuService(TransactionsContext context)
        {
            _context = context;
        }

        public Client ChooseSender()
        {
            Console.WriteLine("\nChoose sender:");
            for (var i = 0; i < _context.Clients.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {_context.Clients[i].Firstname} {_context.Clients[i].Lastname}");
            }
            Console.WriteLine();

            var senderId = Convert.ToInt32(Console.ReadLine());
            if (senderId <= 0 || senderId > _context.Clients.Count)
            {
                throw new IndexOutOfRangeException("Invalid id chosen");
            }

            var sender = _context.Clients[senderId - 1];

            Console.WriteLine("\nEnter phone number:");
            var phoneNumber = Console.ReadLine();

            if (!sender.PhoneNumber.Equals(phoneNumber))
            {
                throw new InvalidOperationException("Incorrect phone number");
            }

            Console.WriteLine("\nEnter pin code:");

            if (!int.TryParse(Console.ReadLine(), out var pinCode))
            {
                throw new InvalidCastException("Cannot convert input to integer");
            }

            if (pinCode != sender.PinCode)
            {
                throw new InvalidOperationException("Incorrect pin code");
            }

            return _context.Clients[senderId - 1];
        }

        public Client ChooseReceiver(Client sender)
        {
            Console.WriteLine("Choose receiver:");
            for (var i = 0; i < _context.Clients.Count; i++)
            {
                if (sender.Id != _context.Clients[i].Id)
                {
                    Console.WriteLine($"{i + 1} - {_context.Clients[i].Firstname} {_context.Clients[i].Lastname}");
                }

            }
            Console.WriteLine();

            var receiverId = Convert.ToInt32(Console.ReadLine());

            if (receiverId <= 0 || receiverId > _context.Clients.Count || _context.Clients[receiverId - 1].Id == sender.Id)
            {
                throw new IndexOutOfRangeException("Invalid id chosen");
            }

            return _context.Clients[receiverId - 1];
        }

        public decimal GetAmountOfMoney(Client sender)
        {
            Console.WriteLine(sender);
            Console.WriteLine("\nEnter amount of money: ");
            if (!decimal.TryParse(Console.ReadLine(), out var amount))
            {
                throw new InvalidCastException("Cannot convert input to decimal");
            }

            if (amount <= 0 || amount > sender.Balance)
            {
                throw new InvalidOperationException("Incorrect amount of money");
            }

            return amount;
        }

        public TransactionType ChooseTransactionType()
        {
            Console.WriteLine("\nTransaction Type:");
            var transactionTypes = Enum.GetValues<TransactionType>();
            for (var i = 0; i < transactionTypes.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {transactionTypes[i]}");
            }

            Console.WriteLine("Choose transaction type: ");

            var typeId = Convert.ToInt32(Console.ReadLine());

            if (typeId <= 0 || typeId > transactionTypes.Length)
            {
                throw new IndexOutOfRangeException("Invalid id chosen");
            }

            return transactionTypes[typeId - 1];
        }
    }
}
