import { GetEquipmentResumed } from "../../results/equipment/GetEquipmentResumed.model";

export class GetDashBoardResult {
    ListOfAndroid: GetEquipmentResumed[];
    ListOfManufacturers: GetEquipmentResumed[];
    ListOfOnlineOfflineDevices: GetEquipmentResumed[];
}