import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { AuthService } from 'src/app/services/auth.service';
import { BaseCommandResult } from 'src/app/results/BaseCommandResult.model';
import { UserService } from 'src/app/services/user.service';

@Component({
    selector: 'app-user-cu',
    templateUrl: './user-cu.component.html'
})
export class UserCuComponent implements OnInit {
    baseCommandResult: BaseCommandResult;

    constructor(public service: UserService,
        public dialogRef: MatDialogRef<UserCuComponent>) { }

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
        this.service.createUser(this.service.form.value).subscribe(result => {
            this.baseCommandResult = result as BaseCommandResult;
            if (this.baseCommandResult.Success) {
                this.onClose();
            }
        });
    }

    update() {
        this.service.updateUser(this.service.form.value).subscribe(result => {
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