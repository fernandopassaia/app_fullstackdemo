using AppFullStackDemo.Domain.Commands;
using AppFullStackDemo.Domain.Commands.DeviceModel;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Handlers.Contracts;
using AppFullStackDemo.Domain.Repositories;
using Flunt.Notifications;

namespace AppFullStackDemo.Domain.Handlers
{
    public class DeviceModelHandler :
        Notifiable,
        IHandler<CreateDeviceModelCommand>,
        IHandler<UpdateDeviceModelCommand>
    {
        private readonly IDeviceModelRepository _repository;
        private readonly IManufacturerRepository _manufacturerRepository;

        public DeviceModelHandler(IDeviceModelRepository repository, IManufacturerRepository manufacturerRepository)
        {
            _repository = repository;
            _manufacturerRepository = manufacturerRepository;
        }

        public IBaseCommandResult Handle(CreateDeviceModelCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new BaseCommandResult(false, "Need to fix the errors on DeviceModel", command.Notifications);

            var manufacturer = _manufacturerRepository.GetById(command.ManufacturerId);
            if (manufacturer == null)
                return new BaseCommandResult(false, "Manufacturer not found", null);

            var deviceModel = new DeviceModel(command.Description, manufacturer);

            _repository.Create(deviceModel);

            return new BaseCommandResult(true, "DeviceModel Saved with Success!", deviceModel);
        }

        public IBaseCommandResult Handle(UpdateDeviceModelCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new BaseCommandResult(false, "Need to fix the errors on DeviceModel", command.Notifications);

            var manufacturer = _manufacturerRepository.GetById(command.ManufacturerId);
            if (manufacturer == null)
                return new BaseCommandResult(false, "Manufacturer not found", null);

            var deviceModel = _repository.GetById(command.Id);
            if (deviceModel == null)
                return new BaseCommandResult(false, "DeviceModel not found", null);

            deviceModel.Update(command.Description, manufacturer);
            _repository.Update(deviceModel);

            return new BaseCommandResult(true, "User Updated with Success!", deviceModel);
        }
    }
}