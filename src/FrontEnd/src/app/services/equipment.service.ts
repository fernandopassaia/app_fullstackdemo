import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { map, catchError, retry } from "rxjs/operators";
import { of } from "rxjs";
import { AppApi } from "../app.api";
import { GetEquipmentReducedResult } from "../results/equipment/GetEquipmentReducedResult.model";
import { GetEquipmentResumed } from "../results/equipment/GetEquipmentResumed.model";

@Injectable({
  providedIn: "root",
})
export class EquipmentService {

  constructor(private http: HttpClient) { }
  listEquipment: GetEquipmentReducedResult[];
  listResumed: GetEquipmentResumed[];

  initializeFormGroup() { }

  GetByEmployee(employeeId: string) {
    let params = new HttpParams();
    params = params.append("employeeId", employeeId);
    return this.http
      .get(`${AppApi.MobileControlApiResourceEquipment}/v1/GetByEmployee`, {
        params: params,
      })
      .pipe(
        retry(2), //if something happens, will retry 2x
        map((res) => (this.listEquipment = res as GetEquipmentReducedResult[])),
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  GetEquipmentResumed(equipmentId: string) {
    let params = new HttpParams();
    params = params.append("equipmentId", equipmentId);
    return this.http
      .get(
        `${AppApi.MobileControlApiResourceEquipment}/v1/GetEquipmentResumed`,
        { params: params }
      )
      .pipe(
        retry(2), //if something happens, will retry 2x
        map((res) => (this.listResumed = res as GetEquipmentResumed[])),
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  GetEquipmentSyntetic(equipmentId: string) {
    let params = new HttpParams();
    params = params.append("equipmentId", equipmentId);
    return this.http
      .get(
        `${AppApi.MobileControlApiResourceEquipment}/v1/GetEquipmentSyntetic`,
        { params: params }
      )
      .pipe(
        retry(2), //if something happens, will retry 2x
        map((res) => (this.listResumed = res as GetEquipmentResumed[])),
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }
}
