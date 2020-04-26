import { Component, OnInit, ElementRef } from '@angular/core';
import { Router, NavigationEnd, NavigationStart } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';

@Component({
  selector: 'app-layout',
  templateUrl: './auth-layout.component.html'
})
export class AuthLayoutComponent implements OnInit {
  private toggleButton: any;
  private sidebarVisible: boolean;
  mobile_menu_visible: any = 0;
  private _router: Subscription;

  constructor(private router: Router, private element: ElementRef) {
      this.sidebarVisible = false;
  }
  ngOnInit(){
    const navbar: HTMLElement = this.element.nativeElement;

    this.toggleButton = navbar.getElementsByClassName('navbar-toggler')[0];
    this._router = this.router.events.filter(event => event instanceof NavigationEnd).subscribe((event: NavigationEnd) => {
      this.sidebarClose();
      const $layer = document.getElementsByClassName('close-layer')[0];
      if ($layer) {
        $layer.remove();
      }
    });
  }
  sidebarOpen() {
    var $toggle = document.getElementsByClassName('navbar-toggler')[0];
      const toggleButton = this.toggleButton;
      const body = document.getElementsByTagName('body')[0];
      setTimeout(function(){
          toggleButton.classList.add('toggled');
      }, 500);
      body.classList.add('nav-open');
      setTimeout(function() {
          $toggle.classList.add('toggled');
      }, 430);

      var $layer = document.createElement('div');
      $layer.setAttribute('class', 'close-layer');


      if (body.querySelectorAll('.wrapper-full-page')) {
          document.getElementsByClassName('wrapper-full-page')[0].appendChild($layer);
      }else if (body.classList.contains('off-canvas-sidebar')) {
          document.getElementsByClassName('wrapper-full-page')[0].appendChild($layer);
      }

      setTimeout(function() {
          $layer.classList.add('visible');
      }, 100);

      $layer.onclick = function() { //asign a function
        body.classList.remove('nav-open');
        this.mobile_menu_visible = 0;
        this.sidebarVisible = false;

        $layer.classList.remove('visible');
        setTimeout(function() {
            $layer.remove();
            $toggle.classList.remove('toggled');
        }, 400);
      }.bind(this);

      body.classList.add('nav-open');
      this.mobile_menu_visible = 1;
      this.sidebarVisible = true;
  };
  sidebarClose() {
    var $toggle = document.getElementsByClassName('navbar-toggler')[0];
      const body = document.getElementsByTagName('body')[0];
      this.toggleButton.classList.remove('toggled');
      var $layer = document.createElement('div');
      $layer.setAttribute('class', 'close-layer');

      this.sidebarVisible = false;
      body.classList.remove('nav-open');
      // $('html').removeClass('nav-open');
      body.classList.remove('nav-open');
      if ($layer) {
          $layer.remove();
      }

      setTimeout(function() {
          $toggle.classList.remove('toggled');
      }, 400);

      this.mobile_menu_visible = 0;
  };
  sidebarToggle() {
      if (this.sidebarVisible === false) {
          this.sidebarOpen();
      } else {
          this.sidebarClose();
      }
  }
}
