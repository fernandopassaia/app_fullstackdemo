using AppFullStackDemo.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppFullStackDemo.Domain.Commands.Manufacturer
{
    public class CreateManufacturerCommand : Notifiable, ICommand
    {
        public CreateManufacturerCommand()
        {
        }

        public CreateManufacturerCommand(string description)
        {
            Description = description;
        }

        public string Description { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Description, "Description", "Description cannot be null")
                .HasMaxLengthIfNotNullOrEmpty(Description, 30, "Description", "Description cannot be higher than 30c.")
            );
        }
    }
}