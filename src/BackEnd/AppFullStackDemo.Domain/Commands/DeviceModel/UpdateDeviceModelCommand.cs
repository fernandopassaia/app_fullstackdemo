using AppFullStackDemo.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace AppFullStackDemo.Domain.Commands.DeviceModel
{
    public class UpdateDeviceModelCommand : Notifiable, ICommand
    {
        public UpdateDeviceModelCommand()
        {
        }

        public UpdateDeviceModelCommand(Guid id, string description, Guid manufacturerId)
        {
            Description = description;
            Id = id;
            ManufacturerId = manufacturerId;
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid ManufacturerId { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Description, "Description", "Please inform a Description.")
                .HasMaxLengthIfNotNullOrEmpty(Description, 30, "Description", "Please Inform a Description.")
            );
        }
    }
}