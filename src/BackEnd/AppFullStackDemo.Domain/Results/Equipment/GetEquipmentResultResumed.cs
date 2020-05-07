using System;

namespace AppFullStackDemo.Domain.Results.Equipment
{
    public class GetEquipmentResultResumed
    {
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public string ApiLevel { get; set; }
        public string ApiLevelDesc { get; set; }
        public string SerialNumber { get; set; }
        public string SystemName { get; set; }
        public string SystemVersion { get; set; }
        public string DeviceModel { get; set; }
        public string User { get; set; }
    }
}