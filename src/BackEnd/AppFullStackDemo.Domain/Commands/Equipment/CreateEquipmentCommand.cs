using AppFullStackDemo.Domain.Commands.Contracts;
using AppFullStackDemo.Shared.Validations;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace AppFullStackDemo.Domain.Commands.Equipment
{
    public class CreateEquipmentCommand : Notifiable, ICommand
    {
        public CreateEquipmentCommand()
        {
        }

        public CreateEquipmentCommand(string androidId, string imei1, string imei2, string phoneNumber, string macAddress, string apiLevel,
            string apiLevelDesc, string serialNumber, string systemName, string systemVersion, string manufacturer, string model, Guid userId)
        {
            AndroidId = androidId;
            Imei1 = imei1;
            Imei2 = imei2;
            PhoneNumber = phoneNumber;
            MacAddress = macAddress;
            ApiLevel = FieldsFormaters.normalizeStr(apiLevel);
            ApiLevelDesc = FieldsFormaters.normalizeStr(apiLevelDesc);
            SerialNumber = serialNumber;
            SystemName = systemName;
            SystemVersion = systemVersion;
            Manufacturer = manufacturer;
            Model = model;
            UserId = userId;
        }

        public string AndroidId { get; set; }
        public string Imei1 { get; set; }
        public string Imei2 { get; set; }
        public string PhoneNumber { get; set; }
        public string MacAddress { get; set; }
        public string ApiLevel { get; set; }
        public string ApiLevelDesc { get; set; }
        public string SerialNumber { get;  set; }
        public string SystemName { get; set; }
        public string SystemVersion { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public Guid UserId { get; set; }

        public void Validate()
        {
            // I'll not validate too much here because this info will come from device
            // and the API on Device always take all values (will not be edited by user)
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(AndroidId, "AndroidId", "Please inform an AndroidId.")
                .HasMaxLengthIfNotNullOrEmpty(AndroidId, 30, "AndroidId", "Please inform an AndroidId.")
            );
        }
    }
}