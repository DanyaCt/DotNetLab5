namespace DotNetLab5.Entities
{
    internal class Transaction
    {
        public Guid Id { get; set; }
        public decimal TransactionAmount { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public Client Sender { get; set; }
        public Client Receiver { get; set; }
    }
}
