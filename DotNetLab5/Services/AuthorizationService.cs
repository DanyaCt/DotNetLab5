using DotNetLab5.Contexts;

namespace DotNetLab5.Services
{
    internal class AuthorizationService
    {
        private readonly TransactionsContext _context;

        public AuthorizationService(TransactionsContext context)
        {
            _context = context;
        }

        public bool Authorize(string phoneNumber, int pinCode)
        {
            var client = _context.Clients.FirstOrDefault(x => x.PhoneNumber.Equals(phoneNumber) && x.PinCode == pinCode);

            return client is not null;
        }
    }
}
