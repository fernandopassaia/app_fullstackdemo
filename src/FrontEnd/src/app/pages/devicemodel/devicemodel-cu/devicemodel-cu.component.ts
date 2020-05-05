import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { NotificationService } from 'src/app/shared/notification.service';
import { BaseCommandResult } from 'src/app/models/BaseCommandResult.model';
import { DeviceModelService } from 'src/app/services/devicemodel.service';
import { GetDeviceModelResult } from 'src/app/models/devicemodel/GetDeviceModelResult.model';
import { ManufacturerCategoryService } from 'src/app/services/manufacturercategory.service';
import { GetManufacturerCategoryResult } from 'src/app/models/manufacturercategory/GetManufacturerCategoryResult.model';

@Component({
  selector: 'app-devicemodel-cu',
  templateUrl: './devicemodel-cu.component.html'
})

export class DeviceModelCuComponent implements OnInit {
  baseCommandResult: BaseCommandResult;
  listDeviceModel: GetDeviceModelResult[];
  listManufacturerCategory: GetManufacturerCategoryResult[];

  constructor(public service: DeviceModelService,
    public serviceManufacturerCategory: ManufacturerCategoryService,    
    public dialogRef: MatDialogRef<DeviceModelCuComponent>) { }

  ngOnInit() {
    this.loadManufacturerCategory();
  }

  loadManufacturerCategory() {
    this.serviceManufacturerCategory.getManufacturerCategory().subscribe(
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