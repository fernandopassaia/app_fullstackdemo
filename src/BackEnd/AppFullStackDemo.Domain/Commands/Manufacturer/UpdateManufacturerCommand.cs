using AppFullStackDemo.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppFullStackDemo.Domain.Commands.Manufacturer
{
    public class UpdateManufacturerCommand : Notifiable, ICommand
    {
        public UpdateManufacturerCommand()
        {
        }

        public UpdateManufacturerCommand(Guid id, string description)
        {
            Description = description;
            Id = id;
        }

        public Guid Id { get; set; }
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