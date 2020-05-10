//myClass.js
export default class CreateEquipmentCommand {
    AndroidId;
    Imei1;
    Imei2;
    PhoneNumber;
    MacAddress;
    ApiLevel;
    ApiLevelDesc;
    SerialNumber;
    SystemName;
    SystemVersion;
    Manufacturer;
    Model;
    UserId;

    constructor(
        androidId,
        imei1,
        imei2,
        phoneNumber,
        macAddress,
        apiLevel,
        apiLevelDesc,
        serialNumber,
        systemName,
        systemVersion,
        manufacturer,
        model,
        userId
    ) {
        this.AndroidId = androidId;
        this.Imei1 = imei1;
        this.Imei2 = imei2;
        this.PhoneNumber = phoneNumber;
        this.MacAddress = macAddress;
        this.ApiLevel = apiLevel;
        this.ApiLevelDesc = apiLevelDesc;
        this.SerialNumber = serialNumber;
        this.SystemName = systemName;
        this.SystemVersion = systemVersion;
        this.Manufacturer = manufacturer;
        this.Model = model;
        this.UserId = userId;
    }
}