import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { map, catchError, retry } from "rxjs/operators";
import { of } from "rxjs";
import { AppApi } from "../app.api";
import { GetManufacturerResult } from "../results/manufacturer/GetManufacturerResult.model";
import { CreateManufacturerCommand } from "../commands/manufacturer/CreateManufacturerCommand.model";
import { UpdateManufacturerCommand } from "../commands/manufacturer/UpdateManufacturerCommand.model";

@Injectable({
  providedIn: "root",
})
export class ManufacturerService {
  constructor(private http: HttpClient) { }
  listManufacturer: GetManufacturerResult[];

  // I've created a group for the controls of the form
  form: FormGroup = new FormGroup({
    Id: new FormControl(""),
    Description: new FormControl("", Validators.required),
  });

  initializeFormGroup() {
    this.form.setValue({
      Id: 0,
      Description: "",
    });
  }

  createManufacturer(command: CreateManufacturerCommand) {
    return this.http
      .post(
        `${AppApi.MobileControlApiResourceManufacturer}/v1`,
        JSON.stringify(command)
      )
      .pipe(
        retry(2), //if something happens, will retry 2x
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  updateManufacturer(command: UpdateManufacturerCommand) {
    return this.http
      .put(
        `${AppApi.MobileControlApiResourceManufacturer}/v1/` + command.Id,
        JSON.stringify(command)
      )
      .pipe(
        retry(2), //if something happens, will retry 2x
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  deleteManufacturer(id: string) {
    return this.http
      .delete(`${AppApi.MobileControlApiResourceManufacturer}/v1/` + id)
      .pipe(
        retry(3), //if something happens, will retry 2x
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  getManufacturers() {
    return this.http
      .get(`${AppApi.MobileControlApiResourceManufacturer}/v1/`)
      .pipe(
        retry(2), //if something happens, will retry 2x
        map((res) => (this.listManufacturer = res as GetManufacturerResult[])),
        catchError((err) => {
          return of(null); //if exception happens, i'll return null
        })
      );
  }

  populateForm(manufacturer) {
    this.http
      .get(
        `${AppApi.MobileControlApiResourceManufacturer}/v1/` + manufacturer.Id)
      .subscribe((res) => {
        const ManufacturerToBeChanged = res as GetManufacturerResult;
        this.form.setValue({
          Id: ManufacturerToBeChanged.Id,
          Description: ManufacturerToBeChanged.Description,
        });
      });
  }
}
