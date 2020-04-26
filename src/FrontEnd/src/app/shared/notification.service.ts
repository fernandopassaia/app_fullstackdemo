//Component Build by Fernando with 2 different notifications system
//First two methods (Snack) and Last for Pannels

import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material';
declare var $: any;

@Injectable({
  providedIn: 'root'
})

export class NotificationService {
  constructor(public snackBar: MatSnackBar) { }

  config: MatSnackBarConfig = {
    duration: 4000,
    horizontalPosition: 'right',
    verticalPosition: 'top',
    panelClass: 'z-index: 10000 !important'
  };

  showSuccessMessageSnack(msg) {
    this.config['panelClass'] = ['notification', 'success']; // CSS File
    this.snackBar.open(msg, '', this.config);
  }

  showWarnMessageSnack(msg) {
    this.config['panelClass'] = ['notification', 'warn'];
    this.snackBar.open(msg, '', this.config);
  }

  //static because i don't need to instance or inject to use it
  static showNotification(color, from, align, nMessage, message) {
    //const type = ['', 'info', 'success', 'warning', 'danger'];
    //const color = Math.floor((Math.random() * 4) + 1);

    $.notify({
      icon: "notifications",
      message: "<b>" + nMessage + "</b> - " + message

    }, {
      type: color,
      timer: 4000,
      placement: {
        from: from,
        align: align
      },
      template: '<div data-notify="container" class="col-xl-4 col-lg-4 col-11 col-sm-4 col-md-4 alert alert-{0} alert-with-icon" role="alert">' +
        '<button mat-button  type="button" aria-hidden="true" class="close mat-button" data-notify="dismiss">  <i class="material-icons">close</i></button>' +
        '<i class="material-icons" data-notify="icon">notifications</i> ' +
        '<span data-notify="title">{1}</span> ' +
        '<span data-notify="message">{2}</span>' +
        '<div class="progress" data-notify="progressbar">' +
        '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
        '</div>' +
        '<a href="{3}" target="{4}" data-notify="url"></a>' +
        '</div>'
    });
  }
}