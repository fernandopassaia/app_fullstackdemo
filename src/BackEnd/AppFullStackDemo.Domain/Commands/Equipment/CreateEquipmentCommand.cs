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
             string apiLevelDesc, string serialNumber, string systemName, string systemVersion, Guid deviceModelId, Guid userId)
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
            DeviceModelId = deviceModelId;
            UserId = userId;
        }

        public string AndroidId { get; private set; }
        public string Imei1 { get; private set; }
        public string Imei2 { get; private set; }
        public string PhoneNumber { get; private set; }
        public string MacAddress { get; private set; }
        public string ApiLevel { get; private set; }
        public string ApiLevelDesc { get; private set; }
        public string SerialNumber { get; private set; }
        public string SystemName { get; private set; }
        public string SystemVersion { get; private set; }
        public Guid DeviceModelId { get; private set; }
        public Guid UserId { get; private set; }

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