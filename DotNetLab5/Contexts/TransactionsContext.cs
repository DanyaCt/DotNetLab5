using DotNetLab5.Entities;
using DotNetLab5.Seed;

namespace DotNetLab5.Contexts
{
    internal class TransactionsContext
    {
        public IList<Client> Clients { get; set; }
        public IList<Commission> Commissions { get; set; }

        public TransactionsContext()
        {
            Clients = ClientSeed.GetSeed();
            Commissions = CommissionSeed.GetSeed();
        }
    }
}
