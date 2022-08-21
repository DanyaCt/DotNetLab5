using DotNetLab5.Entities;
using DotNetLab5.Exceptions;
using DotNetLab5.Services;

namespace DotNetLab5.Handlers
{
    internal class CommissionHandler : BaseHandler
    {
        private readonly CommissionService _commissionService;

        public CommissionHandler(CommissionService commissionService)
        {
            _commissionService = commissionService;
        }

        public override void Handle(Transaction transaction)
        {
            if (transaction is null)
                throw new ArgumentNullException(nameof(transaction));

            var commissionRate = _commissionService.GetCommissionRate(transaction.TransactionType);
            if (commissionRate == -1)
                throw new UnhandledException(nameof(CommissionHandler));

            transaction.TransactionAmount += _commissionService.CountCommission(transaction.TransactionAmount, commissionRate);

            if (transaction.TransactionAmount > transaction.Sender.Balance)
                throw new UnhandledException(nameof(CommissionHandler));

            if (_nextHandler is not null)
                _nextHandler.Handle(transaction);
        }
    }
}
