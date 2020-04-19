using AppFullStackDemo.Shared.Validations;

namespace AppFullStackDemo.Domain.Entities
{
    public class Equipment : EntityBase
    {
        public Equipment(string androidId, string imei1, string imei2, string phoneNumber, string macAddress, string apiLevel,
             string apiLevelDesc, string serialNumber, string systemName, string systemVersion, Model modelDevice, User user)
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
            Validate();
        }

        //If someday We'll do the CAR control, create a second table with KM, Engine, etc...        

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
        public Model Model { get; private set; }
        public User User { get; private set; }

        public void Update(string androidId, string imei1, string imei2, string phoneNumber, string macAddress, string apiLevel,
             string apiLevelDesc, string serialNumber, string systemName, string systemVersion, Model modelDevice, User user)
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
            Validate();
        }

        public void Validate()
        {
            //AddNotifications(new Contract()
            //    .IsNotNullOrEmpty(Description, "Description", "Por favor informe uma Descrição.")
            //    .HasMaxLengthIfNotNullOrEmpty(Description, 30, "Description", "Descrição não pode ter mais de 30 caracters.")

            //);
        }
    }
}