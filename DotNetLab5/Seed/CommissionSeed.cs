using DotNetLab5.Entities;

namespace DotNetLab5.Seed
{
    internal class CommissionSeed
    {
        public static IList<Commission> GetSeed()
        {
            return new[]
            {
                new Commission()
                {
                    TransactionType = TransactionType.Common,
                    Amount = 0.05m,
                },
                new Commission()
                {
                    TransactionType = TransactionType.Preferential,
                    Amount = 0.02m,
                },
                new Commission()
                {
                    TransactionType = TransactionType.National,
                    Amount = 0.2m,
                },
                new Commission()
                {
                    TransactionType = TransactionType.Intrabank,
                    Amount = 0m,
                }
            };
        }
    }
}
