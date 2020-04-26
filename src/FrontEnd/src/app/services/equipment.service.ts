import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { map, catchError, retry } from "rxjs/operators";
import { of } from "rxjs";
import { AppApi } from "../app.api";
import { GetEquipmentReducedResult } from "../models/equipment/GetEquipmentReducedResult.model";
import { GetEquipmentResumed } from "../models/equipment/GetEquipmentResumed.model";
import { GetEquipmentResult } from "../models/equipment/GetEquipmentResult.model";

@Injectable({
  providedIn: "root",
})
export class EquipmentService {
  headers = {
    headers: new HttpHeaders({
      "Content-Type": "application/json",
    }),
  };

  constructor(private http: HttpClient) {}
  listEquipment: GetEquipmentReducedResult[];
  listResumed: GetEquipmentResumed[];
  equipmentDetail: GetEquipmentResult;

  initializeFormGroup() {}

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

  GetById(equipmentId: string) {
    let params = new HttpParams();
    params = params.append("equipmentId", equipmentId);
    return this.http
      .get(`${AppApi.MobileControlApiResourceEquipment}/v1/GetById`, {
        params: params,
      })
      .pipe(
        retry(2), //if something happens, will retry 2x
        map((res) => (this.equipmentDetail = res as GetEquipmentResult)),
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }
}
