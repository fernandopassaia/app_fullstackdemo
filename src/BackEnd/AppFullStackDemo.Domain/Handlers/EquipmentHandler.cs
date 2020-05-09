using System;
using AppFullStackDemo.Domain.Commands.Equipment;
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
        private readonly IManufacturerRepository _manufacturerRepository;
        public EquipmentHandler(IEquipmentRepository repository, IDeviceModelRepository deviceModelRepository, IUserRepository userRepository, IManufacturerRepository manufacturerRepository)
        {
            _repository = repository;
            _deviceModelRepository = deviceModelRepository;
            _userRepository = userRepository;
            _manufacturerRepository = manufacturerRepository;
        }

        public IBaseCommandResult Handle(CreateEquipmentCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new BaseCommandResult(false, "Need to fix the errors on Equipment", command.Notifications);

            var user = _userRepository.GetById(command.UserId);
            if (user == null)
                return new BaseCommandResult(false, "User not found", null);

            //logic here: if manufacturer and/or model don't exists, i will create it and attach to equipment
            var manufacturer = _manufacturerRepository.GetByDescription(command.Manufacturer);
            if(manufacturer == null)
            {
                manufacturer = new Manufacturer(command.Manufacturer);
                _manufacturerRepository.Create(manufacturer);                
            }
            
            var deviceModel = _deviceModelRepository.GetByDescriptionAndManufacturer(command.Model, manufacturer);
            if(deviceModel == null)
            {
                deviceModel = new DeviceModel(command.Model, manufacturer);
                _deviceModelRepository.Create(deviceModel);
            }

            var equipment = new Equipment(command.AndroidId, command.Imei1, command.Imei2, command.PhoneNumber, command.MacAddress,
            command.ApiLevel, command.ApiLevelDesc, command.SerialNumber, command.SystemName, command.SystemVersion, deviceModel, user);

            _repository.Create(equipment);

            return new BaseCommandResult(true, "Equipment Saved with Success!", equipment);
        }

        public IBaseCommandResult Handle(Guid id)
        {
            var equipment = _repository.GetById(id);
            if (equipment == null)
                return new BaseCommandResult(false, "Equipment not found", null);

            equipment.Remove();
            _repository.Update(equipment);
            return new BaseCommandResult(true, "Equipment Deleted with Success!", null);
        }

        // Note: My Goal here is to create the Equipment (the post will comes from the MobileApp) and done. Right now,
        // there will be no option to EDIT or update the Data once the device will not change itself hardware. To be done...
    }
}