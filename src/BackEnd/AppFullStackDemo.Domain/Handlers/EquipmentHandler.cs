using AppFullStackDemo.Domain.Commands.DeviceModel;
using AppFullStackDemo.Domain.Entities;
using AppFullStackDemo.Domain.Handlers.Contracts;
using AppFullStackDemo.Domain.Repositories;
using AppFullStackDemo.Domain.Results;
using Flunt.Notifications;

namespace AppFullStackDemo.Domain.Handlers
{
    public class EquipmentHandler :
        Notifiable,
        IHandler<CreateEquipmentCommand>
    {
        private readonly IEquipmentRepository _repository;
        private readonly IDeviceModelRepository _deviceModelRepository;
        private readonly IUserRepository _userRepository;
        public EquipmentHandler(IEquipmentRepository repository, IDeviceModelRepository deviceModelRepository, IUserRepository userRepository)
        {
            _repository = repository;
            _deviceModelRepository = deviceModelRepository;
            _userRepository = userRepository;
        }

        public IBaseCommandResult Handle(CreateEquipmentCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new BaseCommandResult(false, "Need to fix the errors on Equipment", command.Notifications);

            var deviceModel = _deviceModelRepository.GetById(command.DeviceModelId);
            if (deviceModel == null)
                return new BaseCommandResult(false, "Device-Model not found", null);

            var user = _userRepository.GetById(command.UserId);
            if (user == null)
                return new BaseCommandResult(false, "User not found", null);

            var equipment = new Equipment(command.AndroidId, command.Imei1, command.Imei2, command.PhoneNumber, command.MacAddress,
            command.ApiLevel, command.ApiLevelDesc, command.SerialNumber, command.SystemName, command.SystemVersion, deviceModel, user);

            _repository.Create(equipment);

            return new BaseCommandResult(true, "Equipment Saved with Success!", equipment);
        }
    }
}