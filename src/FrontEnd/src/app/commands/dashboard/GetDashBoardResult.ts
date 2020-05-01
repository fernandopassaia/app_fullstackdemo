import { GetEquipmentResumed } from "../equipment/GetEquipmentResumed.model";

export class GetDashBoardResult {
    ListOfAndroid: GetEquipmentResumed[];
    ListOfManufacturers: GetEquipmentResumed[];
    ListOfOnlineOfflineDevices: GetEquipmentResumed[];
}