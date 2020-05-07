using System;

namespace AppFullStackDemo.Domain.Results.Equipment
{
    public class GetEquipmentResult
    {
        public string AndroidId { get; set; }
        public string Imei1 { get; set; }
        public string Imei2 { get; set; }
        public string PhoneNumber { get; set; }
        public string MacAddress { get; set; }
        public string ApiLevel { get; set; }
        public string ApiLevelDesc { get; set; }
        public string SerialNumber { get; set; }
        public string SystemName { get; set; }
        public string SystemVersion { get; set; }
        public Guid DeviceModelId { get; set; }
        public string DeviceModel { get; set; }
        public Guid UserId { get; set; }
        public string User { get; set; }
    }
}