using AppFullStackDemo.Domain.Commands;
using AppFullStackDemo.Domain.Commands.Contracts;

namespace AppFullStackDemo.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        BaseCommandResult Handle(T command);
    }
}