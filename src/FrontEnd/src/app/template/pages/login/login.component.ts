import { Component, OnInit, ElementRef, OnDestroy } from '@angular/core';
import { GetLoggedUserResult } from 'src/app/models/userprofile/GetLoggedUserResult.model';
import { NotificationService } from 'src/app/shared/notification.service';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

declare var $: any;

@Component({
    selector: 'app-login-cmp',
    templateUrl: './login.component.html'
})

export class LoginComponent implements OnInit, OnDestroy {
    test: Date = new Date();
    private toggleButton: any;
    private sidebarVisible: boolean;
    private nativeElement: Node;
    logUserResult: GetLoggedUserResult;
    public errors: any[] = [];

    constructor(private element: ElementRef, public service: AuthService, private router: Router) {
        this.nativeElement = element.nativeElement;
        this.sidebarVisible = false;
    }

    ngOnInit() {
        //Fernando - I'll check if already have a Token, if yes, I'll send user to Panel automaticaly
        if (this.service.getJwtToken() != null) {
            this.router.navigateByUrl('/dashboard');
        }

        var navbar: HTMLElement = this.element.nativeElement;
        this.toggleButton = navbar.getElementsByClassName('navbar-toggle')[0];
        const body = document.getElementsByTagName('body')[0];
        body.classList.add('login-page');
        body.classList.add('off-canvas-sidebar');
        const card = document.getElementsByClassName('card')[0];
        setTimeout(function () {
            // after 1000 ms we add the class animated to the login/register card
            card.classList.remove('card-hidden');
        }, 700);
    }

    sidebarToggle() {
        var toggleButton = this.toggleButton;
        var body = document.getElementsByTagName('body')[0];
        var sidebar = document.getElementsByClassName('navbar-collapse')[0];
        if (this.sidebarVisible == false) {
            setTimeout(function () {
                toggleButton.classList.add('toggled');
            }, 500);
            body.classList.add('nav-open');
            this.sidebarVisible = true;
        } else {
            this.toggleButton.classList.remove('toggled');
            this.sidebarVisible = false;
            body.classList.remove('nav-open');
        }
    }

    ngOnDestroy() {
        const body = document.getElementsByTagName('body')[0];
        body.classList.remove('login-page');
        body.classList.remove('off-canvas-sidebar');
    }

    // Fernando: Will authenticate the user, if authenticated, will save the Token in LocalStorage
    onSubmit() {
        this.service.login({ username: this.form.controls['UsernameOrEmail'].value, password: this.form.controls['Password'].value }).subscribe(
            (result: any) => { //if i have any kind of result                
                if (result.Success) {
                    this.router.navigateByUrl('/dashboard');
                }
            },
            err => {
                if (err.status == 400)
                    NotificationService.showNotification('warning', 'top', 'right', 'Usuário ou Senha incorretos', err.message);
                else
                    console.log(err);
            }
        );
    }

    //NOTE BY FERNANDO: TO TEST API (the test-method on the backend), Just remove the "2" and this method will be called
    onSubmit2() {
        this.service.testApi().subscribe(
            (result: any) => { //if i have any kind of result                

            },
            err => {
                if (err.status == 400)
                    NotificationService.showNotification('warning', 'top', 'right', 'Usuário ou Senha incorretos', err.message);
                else
                    console.log(err);
            }
        );
    }
}
