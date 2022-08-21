using DotNetLab5.Entities;
using DotNetLab5.Loggers;

namespace DotNetLab5.Handlers
{
    internal class LogHandler : BaseHandler
    {
        private readonly ILogger _logger;

        public LogHandler(ILogger logger)
        {
            _logger = logger;
        }

        public override void Handle(Transaction transaction)
        {
            if (transaction is null)
                throw new ArgumentNullException(nameof(transaction));

            _logger.Log(
                $"TRANSACTION {transaction.Id} Type: {transaction.TransactionType}:" +
                $"\nCreated at: {transaction.CreatedAt:G} - Amount: {transaction.TransactionAmount}" +
                $"\nSENDER: {transaction.Sender.Firstname} {transaction.Sender.Lastname}" +
                $"\nRECEIVER: {transaction.Receiver.Firstname} {transaction.Receiver.Lastname}\n");

            if(_nextHandler is not null)
                _nextHandler.Handle(transaction);

        }
    }
}
