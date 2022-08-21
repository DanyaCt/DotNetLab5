namespace DotNetLab5.Entities
{
    internal class Client
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Balance { get; set; }
        public int PinCode { get; set; }
        public override string ToString()
        {
            return $"Id: {Id} - {Firstname} {Lastname}" +
                   $"\nPhone number: {PhoneNumber}" +
                   $"\nYour balance: {Balance:0.00}$";
        }
    }
}
