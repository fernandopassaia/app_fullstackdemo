using Flunt.Validations;
using System.Collections.Generic;

namespace AppFullStackDemo.Domain.Entities
{
    public class Manufacturer : EntityBase
    {
        public Manufacturer(string description)
        {
            Description = description;
            Validate();
        }

        //Parameters and ObjectValues
        public string Description { get; private set; }

        //Manufacturer has a collection of ManufacturerCategories
        public List<DeviceModel> DevicesModel { get; private set; }

        public void Update(string description)
        {
            Description = description;
            Validate();
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Description, "Description", "Description cannot be null")
                .HasMaxLengthIfNotNullOrEmpty(Description, 30, "Description", "Description cannot be higher than 30c.")
            );
        }
    }
}