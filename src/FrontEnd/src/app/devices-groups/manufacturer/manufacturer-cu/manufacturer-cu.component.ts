import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { NotificationService } from 'src/app/shared/notification.service';
import { BaseCommandResult } from 'src/app/models/BaseCommandResult.model';
import { ManufacturerService } from 'src/app/services/manufacturer.service';

@Component({
  selector: 'app-manufacturer-cu',
  templateUrl: './manufacturer-cu.component.html'
})

export class ManufacturerCuComponent implements OnInit {
  baseCommandResult: BaseCommandResult;

  constructor(public service: ManufacturerService,
    public dialogRef: MatDialogRef<ManufacturerCuComponent>) { }

  ngOnInit() {
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
    this.service.createManufacturer(this.service.form.value).subscribe(result => {
      this.baseCommandResult = result as BaseCommandResult;
      if (this.baseCommandResult.Success) {
        this.onClose();
      }
    });
  }

  update() {
    this.service.updateManufacturer(this.service.form.value).subscribe(result => {
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