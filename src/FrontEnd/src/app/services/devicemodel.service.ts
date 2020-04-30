import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { map, catchError, retry } from "rxjs/operators";
import { of } from "rxjs";
import { GetDeviceModelResult } from "../models/devicemodel/GetDeviceModelResult.model";
import { AppApi } from "../app.api";
import { CreateDeviceModelCommand } from "../models/devicemodel/CreateDeviceModelCommand.model";
import { UpdateDeviceModelCommand } from "../models/devicemodel/UpdateDeviceModelCommand.model";

@Injectable({
  providedIn: "root",
})
export class DeviceModelService {
  constructor(private http: HttpClient) { }
  listDeviceModel: GetDeviceModelResult[];

  // I've created a group for the controls of the form
  form: FormGroup = new FormGroup({
    Id: new FormControl(""),
    Description: new FormControl("", Validators.required),
    ManufacturerCategory: new FormControl("1"),
  });

  initializeFormGroup() {
    this.form.setValue({
      Id: 0,
      Description: "",
      ManufacturerCategory: "1",
    });
  }

  getDeviceModel() {
    return this.http
      .get(`${AppApi.MobileControlApiResourceDeviceModel}/v1`)
      .pipe(
        retry(2), //if something happens, will retry 2x
        map((res) => (this.listDeviceModel = res as GetDeviceModelResult[])),
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  createDeviceModel(command: CreateDeviceModelCommand) {
    return this.http
      .post(
        `${AppApi.MobileControlApiResourceDeviceModel}/v1`,
        JSON.stringify(command)
      )
      .pipe(
        retry(2), //if something happens, will retry 2x
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  updateDeviceModel(command: UpdateDeviceModelCommand) {
    return this.http
      .put(
        `${AppApi.MobileControlApiResourceDeviceModel}/v1`,
        JSON.stringify(command)
      )
      .pipe(
        retry(2), //if something happens, will retry 2x
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  deleteDeviceModel(Id: string) {
    return this.http
      .delete(`${AppApi.MobileControlApiResourceDeviceModel}/v1/` + Id)
      .pipe(
        retry(3), //if something happens, will retry 2x
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  populateForm(DeviceModel) {
    this.http
      .get(`${AppApi.MobileControlApiResourceDeviceModel}/v1/` + DeviceModel.Id)
      .subscribe((res) => {
        const DeviceModelToBeChanged = res as UpdateDeviceModelCommand;
        this.form.setValue({
          Id: DeviceModelToBeChanged.Id,
          Description: DeviceModelToBeChanged.Description,
          ManufacturerCategory: DeviceModelToBeChanged.ManufacturerCategory.toString(), //precisa jogar pra string senão não pega!
        });
      });
  }
}
