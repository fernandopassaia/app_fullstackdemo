import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { EmployeeService } from 'src/app/services/employee.service';
import { BaseCommandResult } from 'src/app/models/BaseCommandResult.model';
import { GetCostCenterAreaResult } from 'src/app/models/costcenterarea/GetCostCenterAreaResult.model';
import { GetPositionResult } from 'src/app/models/position/GetPositionResult.model';
import { GetSubsidiaryResult } from 'src/app/models/subsidiary/GetSubsidiaryResult.model';
import { GetCompanyReducedResult } from 'src/app/models/company/GetCompanyReducedResult.model';
import { GetUserProfileResult } from 'src/app/models/userprofile/GetUserProfileResult.model';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-employee-cu',
  templateUrl: './employee-cu.component.html'
})
export class EmployeeCuComponent implements OnInit {
  baseCommandResult: BaseCommandResult;
  listCompanyReduced: GetCompanyReducedResult[];
  listSubsidiary: GetSubsidiaryResult[];
  listPosition: GetPositionResult[];
  listCostCenterArea: GetCostCenterAreaResult[];
  listUserProfile: GetUserProfileResult[];
  listOfUserTypes: any[];

  constructor(public service: EmployeeService,
    public userProfileService: AuthService,
    public dialogRef: MatDialogRef<EmployeeCuComponent>) { }

  ngOnInit() {
    this.loadCompanys();
  }

  loadCompanys() {

  }

  reloadSubsidiaryPositionCostCenterAreaUserProfile() {
    this.userProfileService.getUserProfiles().subscribe(
      list => {
        this.listUserProfile = list;
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
    this.service.createEmployee(this.service.form.value).subscribe(result => {
      this.baseCommandResult = result as BaseCommandResult;
      if (this.baseCommandResult.Success) {
        this.onClose();
      }
    });
  }

  update() {
    this.service.updateEmployee(this.service.form.value).subscribe(result => {
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