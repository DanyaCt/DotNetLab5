using DotNetLab5.Entities;

namespace DotNetLab5.Handlers
{
    internal interface IHandler
    {
        void Handle(Transaction transaction);
        void SetNext(IHandler next);
    }
}
