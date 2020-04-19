using Flunt.Validations;
using System.Collections.Generic;

namespace AppFullStackDemo.Domain.Entities
{
    public class Model : EntityBase
    {
        public Model(string description, Manufacturer manufacturer)
        {
            Description = description;
            Manufacturer = manufacturer;
            Validate();
        }

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