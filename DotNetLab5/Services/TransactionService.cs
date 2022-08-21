using DotNetLab5.Entities;
using DotNetLab5.Exceptions;
using DotNetLab5.Handlers;

namespace DotNetLab5.Services
{
    internal class TransactionService
    {
        private readonly IHandler _handler;

        public TransactionService(IHandler handler)
        {
            _handler = handler;
        }

        public Response PerformTransaction(Client sender, Client receiver, decimal amount, TransactionType type)
        {
            var transaction = new Transaction()
            {
                CreatedAt = DateTimeOffset.Now,
                Id = Guid.NewGuid(),
                Sender = sender,
                Receiver = receiver,
                TransactionAmount = amount,
                TransactionType = type,
            };

            try
            {
                _handler.Handle(transaction);
            }
            catch (Exception e)
            {
                if (e is UnhandledException ue)
                {
                    return new Response()
                    {
                        IsSucceeded = false,
                        Message = ue.Message,
                    };
                }

                Console.WriteLine(e.Message);
                return new Response()
                {
                    IsSucceeded = false,
                    Message = e.Message,
                };
            }

            sender.Balance -= transaction.TransactionAmount; // amount + commission
            receiver.Balance += amount;

            return new Response()
            {
                IsSucceeded = true,
                Message = "The transaction is successfully proceed",
            };
        }
    }
}
