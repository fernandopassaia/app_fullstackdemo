using AppFullStackDemo.Domain.Commands.Manufacturer;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Handlers.Contracts;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Domain.Results;
using Flunt.Notifications;

namespace AppFullStackDemo.Domain.Handlers
{
    public class ManufacturerHandler :
        Notifiable,
        IHandler<CreateManufacturerCommand>,
        IHandler<UpdateManufacturerCommand>
    {
        private readonly IManufacturerRepository _repository;

        public ManufacturerHandler(IManufacturerRepository repository)
        {
            _repository = repository;
        }

        public IBaseCommandResult Handle(CreateManufacturerCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new BaseCommandResult(false, "Need to fix the errors on Manufacturer", command.Notifications);

            var manufacturer = new Manufacturer(command.Description);

            _repository.Create(manufacturer);

            return new BaseCommandResult(true, "Manufacturer Saved with Success!", manufacturer);
        }

        public IBaseCommandResult Handle(UpdateManufacturerCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new BaseCommandResult(false, "Need to fix the errors on Manufacturer", command.Notifications);

            var manufacturer = _repository.GetById(command.Id);
            if (manufacturer == null)
                return new BaseCommandResult(false, "Manufacturer not found", null);

            manufacturer.Update(command.Description);

            _repository.Update(manufacturer);

            return new BaseCommandResult(true, "Manufacturer Updated with Success!", manufacturer);
        }
    }
}