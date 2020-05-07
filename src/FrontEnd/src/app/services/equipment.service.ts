import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { map, catchError, retry } from "rxjs/operators";
import { of } from "rxjs";
import { AppApi } from "../app.api";
import { GetEquipmentResult } from "../results/equipment/GetEquipmentResult.model";
import { GetEquipmentResultResumed } from "../results/equipment/GetEquipmentResultResumed.model";

@Injectable({
  providedIn: "root",
})
export class EquipmentService {

  constructor(private http: HttpClient) { }
  listEquipment: GetEquipmentResultResumed[];
  equipmentDetail: GetEquipmentResult[];

  initializeFormGroup() { }

  deleteEquipment(id: string) {
    return this.http
      .delete(`${AppApi.MobileControlApiResourceEquipment}/v1/` + id)
      .pipe(
        retry(3), //if something happens, will retry 2x
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  GetEquipments() {
    return this.http
      .get(
        `${AppApi.MobileControlApiResourceEquipment}/v1/`)
      .pipe(
        retry(2), //if something happens, will retry 2x
        map((res) => (this.listEquipment = res as GetEquipmentResultResumed[])),
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  GetEquipment(id: string) {
    return this.http
      .get(
        `${AppApi.MobileControlApiResourceEquipment}/v1/` + id)
      .pipe(
        retry(2), //if something happens, will retry 2x
        map((res) => (this.equipmentDetail = res as GetEquipmentResult[])),
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  GetEquipmentsByUser(userId: string) {
    return this.http
      .get(`${AppApi.MobileControlApiResourceEquipment}/v1/user/` + userId)
      .pipe(
        retry(2), //if something happens, will retry 2x
        map((res) => (this.listEquipment = res as GetEquipmentResultResumed[])),
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

}
