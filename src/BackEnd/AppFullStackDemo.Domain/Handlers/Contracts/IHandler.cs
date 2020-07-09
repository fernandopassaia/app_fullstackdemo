using AppFullStackDemo.Domain.Commands.Contracts;
using AppFullStackDemo.Domain.Results;

namespace AppFullStackDemo.Domain.Handlers.Contracts
{
    // This the contract for Handler: Handler could be <T>, since T (the handler) implement ICommand
    // So basically all the commands should implement ICommand
    public interface IHandler<T> where T : ICommand
    {
        IBaseCommandResult Handle(T command);
    }
}