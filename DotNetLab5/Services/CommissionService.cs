using DotNetLab5.Contexts;
using DotNetLab5.Entities;

namespace DotNetLab5.Services
{
    internal class CommissionService
    {
        private readonly TransactionsContext _context;
        public CommissionService(TransactionsContext context)
        {
            _context = context;
        }

        public decimal GetCommissionRate(TransactionType type)
        {
            var result = _context.Commissions.FirstOrDefault(x => x.TransactionType == type);
            return result?.Amount ?? -1m;
        }

        public decimal CountCommission(decimal amount, decimal rate)
        {
            return amount * rate;
        }
    }
}
