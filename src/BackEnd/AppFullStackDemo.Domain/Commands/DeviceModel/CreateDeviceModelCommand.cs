using AppFullStackDemo.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppFullStackDemo.Domain.Commands.DeviceModel
{
    public class CreateDeviceModelCommand : Notifiable, ICommand
    {
        public CreateDeviceModelCommand()
        {
        }

        public CreateDeviceModelCommand(string description, Guid manufacturerId)
        {
            Description = description;
            ManufacturerId = manufacturerId;
        }

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