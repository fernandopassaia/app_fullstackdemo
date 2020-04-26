export class GetEquipmentLogResumedCommand {
    Id: string;
    MemoryInUseDesc: string;
    DiskInUseDesc: string;
    IpAddress: string;
    BatteryLevel: string;
    BatteryIsCharging: string;
    DateTimeOnDevice: string;
    Gps_Coords_Latitude: string;
    Gps_Coords_Longitude: string;
    Gps_GoogleLink: string;
    Gps_Timestamp: string;
    CreatedIn: string;
    Gps_BasedOn: string; //0 = Chip GPS, 1 = Internet/3g/Wifi
}