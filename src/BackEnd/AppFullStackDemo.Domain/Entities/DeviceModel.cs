using Flunt.Validations;
using System.Collections.Generic;

namespace AppFullStackDemo.Domain.Entities
{
    public class DeviceModel : EntityBase
    {
        public DeviceModel(string description, Manufacturer manufacturer)
        {
            Description = description;
            Manufacturer = manufacturer;
            Validate();
        }

        protected DeviceModel() { } //This constructor will be used by EF during migrations (for some reason, EF needs a empty constructor to run)

        public string Description { get; private set; }

        public Manufacturer Manufacturer { get; private set; }

        public List<Equipment> EquipmentsList { get; private set; }

        public void Update(string description, Manufacturer manufacturer)
        {
            Description = description;
            Manufacturer = manufacturer;
            Validate();
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Description, "Description", "Please inform a Description.")
                .HasMaxLengthIfNotNullOrEmpty(Description, 30, "Description", "Please Inform a Description.")
            );
        }
    }
}