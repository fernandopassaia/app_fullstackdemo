using Flunt.Validations;

namespace AppFullStackDemo.Domain.Commands.Contracts
{
    public interface ICommand : IValidatable
    {
        // ICommand (and who implement it) will have a Validate() method (from IValidatable) to implement (and validate the DTO)
    }
}