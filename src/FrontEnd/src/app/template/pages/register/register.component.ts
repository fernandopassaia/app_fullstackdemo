import { Component, OnInit, OnDestroy } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { BaseCommandResult } from 'src/app/results/BaseCommandResult.model';
import { NotificationService } from 'src/app/shared/notification.service';

@Component({
  selector: 'app-register-cmp',
  templateUrl: './register.component.html'
})

export class RegisterComponent implements OnInit, OnDestroy {
  test: Date = new Date();

  constructor(private service: UserService) { }

  ngOnInit() {
    const body = document.getElementsByTagName('body')[0];
    body.classList.add('register-page');
    body.classList.add('off-canvas-sidebar');
  }
  ngOnDestroy() {
    const body = document.getElementsByTagName('body')[0];
    body.classList.remove('register-page');
    body.classList.remove('off-canvas-sidebar');
  }

  onSubmit() {
    this.service.createUser(this.service.form.value).subscribe(res => {
      let baseCommandResult = res as BaseCommandResult;
      if (baseCommandResult.Success == true) {
        NotificationService.showNotification('success', 'top', 'right', 'Success', baseCommandResult.Message);
      } else {
        NotificationService.showNotification('warn', 'top', 'right', 'Error', baseCommandResult.Message);
      }
    });
  }
}
