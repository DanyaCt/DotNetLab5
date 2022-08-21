using DotNetLab5.Entities;

namespace DotNetLab5.Handlers
{
    internal abstract class BaseHandler : IHandler
    {
        protected IHandler _nextHandler;
        public abstract void Handle(Transaction transaction);
        public void SetNext(IHandler next)
        {
            _nextHandler = next;
        }
    }
}
