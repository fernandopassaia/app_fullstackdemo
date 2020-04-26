import { ETaskStatus } from "src/app/enums/ETaskStatus";

export class GetBackGroundTaskResult {
  CreatedIn: string;
  TypeOf: number;
  IdentityTypeOf: number;
  PersonToId: string;
  EquipmentId: string;
  Status: ETaskStatus; //ETaskStatus
  ExecutedIn: string;
}
