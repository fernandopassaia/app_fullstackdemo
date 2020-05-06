import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { DeviceModelService } from 'src/app/services/devicemodel.service';
import { BaseCommandResult } from 'src/app/results/BaseCommandResult.model';
import { ManufacturerService } from 'src/app/services/manufacturer.service';
import { GetManufacturerResult } from 'src/app/results/manufacturer/GetManufacturerResult.model';
import { GetDeviceModelResult } from 'src/app/results/devicemodel/GetDeviceModelResult.model';

@Component({
  selector: 'app-devicemodel-cu',
  templateUrl: './devicemodel-cu.component.html'
})

export class DeviceModelCuComponent implements OnInit {
  baseCommandResult: BaseCommandResult;
  listDeviceModel: GetDeviceModelResult[];
  listManufacturerCategory: GetManufacturerResult[];

  constructor(public service: DeviceModelService,
    public serviceManufacturerCategory: ManufacturerService,
    public dialogRef: MatDialogRef<DeviceModelCuComponent>) { }

  ngOnInit() {
    this.loadManufacturerCategory();
  }

  loadManufacturerCategory() {
    this.serviceManufacturerCategory.getManufacturers().subscribe(
      list => {
        this.listManufacturerCategory = list;
      });
  }

  onSubmit() {
    if (this.service.form.valid) {
      if (!this.service.form.get('Id').value) {
        this.insert();
      } else {
        this.update();
      }
    }
  }

  insert() {
    this.service.createDeviceModel(this.service.form.value).subscribe(result => {
      this.baseCommandResult = result as BaseCommandResult;
      if (this.baseCommandResult.Success) {
        this.onClose();
      }
    });
  }

  update() {
    this.service.updateDeviceModel(this.service.form.value).subscribe(result => {
      this.baseCommandResult = result as BaseCommandResult;
      if (this.baseCommandResult.Success) {
        this.onClose();
      }
    });
  }

  onClose() {
    this.service.form.reset();
    this.service.initializeFormGroup();
    this.dialogRef.close(); // here i will CLOSE the popup (modal)
  }
}