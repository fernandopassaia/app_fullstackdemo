using AppFullStackDemo.Domain.Commands.Contracts;
using AppFullStackDemo.Domain.Results;

namespace AppFullStackDemo.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        IBaseCommandResult Handle(T command);
    }
}