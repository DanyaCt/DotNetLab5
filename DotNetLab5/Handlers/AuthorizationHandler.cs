using DotNetLab5.Entities;
using DotNetLab5.Exceptions;
using DotNetLab5.Services;

namespace DotNetLab5.Handlers
{
    internal class AuthorizationHandler : BaseHandler
    {
        private readonly AuthorizationService _authorizationService;

        public AuthorizationHandler(AuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public override void Handle(Transaction transaction)
        {
            if (transaction is null)
                throw new ArgumentNullException(nameof(transaction));

            var handled = _authorizationService.Authorize(transaction.Sender.PhoneNumber, transaction.Sender.PinCode);

            if (!handled)
                throw new UnhandledException(nameof(AuthorizationHandler));

            if(_nextHandler is not null)
                _nextHandler.Handle(transaction);
        }
    }
}
