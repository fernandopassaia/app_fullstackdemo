using AppFullStackDemo.Domain.Commands;
using AppFullStackDemo.Domain.Commands.Contracts;

namespace AppFullStackDemo.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        IBaseCommandResult Handle(T command);
    }
}