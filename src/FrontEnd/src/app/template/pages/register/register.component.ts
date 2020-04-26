import { Component, OnInit, OnDestroy } from '@angular/core';

@Component({
    selector: 'app-register-cmp',
    templateUrl: './register.component.html'
})

export class RegisterComponent implements OnInit, OnDestroy {
    test: Date = new Date();
    ngOnInit() {
      const body = document.getElementsByTagName('body')[0];
      body.classList.add('register-page');
      body.classList.add('off-canvas-sidebar');
    }
    ngOnDestroy(){
      const body = document.getElementsByTagName('body')[0];
      body.classList.remove('register-page');
      body.classList.remove('off-canvas-sidebar');
    }
}
