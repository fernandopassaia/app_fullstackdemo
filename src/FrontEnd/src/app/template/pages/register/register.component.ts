import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-register-cmp',
  templateUrl: './register.component.html'
})

export class RegisterComponent implements OnInit, OnDestroy {
  test: Date = new Date();

  // Note: On the Create I`ll allow user to create just with First and LastName, Username (email) and Password.
  // Once User is logged, if user tries to UPDATE the profile, will be forced to add Address, Phone and other info.
  form: FormGroup = new FormGroup({
    UsernameOrEmail: new FormControl('', Validators.required),
    Password: new FormControl('', Validators.required)
  });

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

  onSubmit() { }
}
