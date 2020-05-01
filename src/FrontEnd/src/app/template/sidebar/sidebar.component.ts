import { Component, OnInit } from '@angular/core';
import PerfectScrollbar from 'perfect-scrollbar';
import { Router } from '@angular/router';
import { GetLoggedUserResult } from 'src/app/models/user/GetLoggedUserResult.model';
import { AuthService } from 'src/app/services/auth.service';

declare const $: any;


//Metadata
export interface RouteInfo {
    path: string;
    title: string;
    type: string;
    icontype: string;
    collapse?: string;
    children?: ChildrenItems[];
}

export interface ChildrenItems {
    path: string;
    title: string;
    ab: string;
    type?: string;
}

//Menu Items
export const ROUTES: RouteInfo[] = [{
    path: '/dashboard',
    title: 'Dashboard',
    type: 'link',
    icontype: 'dashboard'
},

{
    path: '/company',
    title: 'Empresas',
    type: 'link',
    icontype: 'explicit'
},
{
    path: '',
    title: 'Grupos Empresa',
    type: 'sub',
    icontype: 'group',
    collapse: 'groupcompanys',
    children: [
        { path: 'position', title: 'Posições', ab: 'PO' },
        { path: 'subsidiary', title: 'Subsidiária', ab: 'SU' },
        { path: 'costcenterarea', title: 'Área Centro Custo', ab: 'AC' }
    ]
},
{
    path: '',
    title: 'Dispositivos',
    type: 'sub',
    icontype: 'phonelink_ring',
    collapse: 'groupdevices',
    children: [
        { path: 'category', title: 'Categoria', ab: 'CA' },
        { path: 'manufacturer', title: 'Fabricante', ab: 'FA' },
        { path: 'manufacturercategory', title: 'Categoria-Fabricante', ab: 'CF' },
        { path: 'devicemodel', title: 'Modelo Dispositivos', ab: 'MD' },
    ]
},
{
    path: '/employee',
    title: 'Funcionários',
    type: 'link',
    icontype: 'person'
}

    //Parte do Menú do Template do Template
];
@Component({
    selector: 'app-sidebar-cmp',
    templateUrl: 'sidebar.component.html',
})

export class SidebarComponent implements OnInit {
    public menuItems: any[];
    public name: string;
    public email: string;
    public company: string;

    ps: any;
    isMobileMenu() {
        if ($(window).width() > 991) {
            return false;
        }
        return true;
    };

    constructor(public router: Router, public service: AuthService) {
    }

    ngOnInit() {
        //Fernando - Here I`ll get the Profile of the User Based on the Token. NOTE: On 012020 this method was
        //commented because i have the Information on LocalStorage. So I'll get from there...
        // this.service.getUserProfile().subscribe(
        //     res => {
        //         const userLogged = res as GetLoggedUserResult;
        //         this.name = userLogged.NameUser;
        //         this.email = userLogged.EmailAddress;
        //     });

        this.name = localStorage.getItem('acEN');
        this.email = localStorage.getItem('acEE');
        this.company = localStorage.getItem('acCN');

        this.menuItems = ROUTES.filter(menuItem => menuItem);
        if (window.matchMedia(`(min-width: 960px)`).matches && !this.isMac()) {
            const elemSidebar = <HTMLElement>document.querySelector('.sidebar .sidebar-wrapper');
            this.ps = new PerfectScrollbar(elemSidebar);
        }
    }
    updatePS(): void {
        if (window.matchMedia(`(min-width: 960px)`).matches && !this.isMac()) {
            this.ps.update();
        }
    }
    isMac(): boolean {
        let bool = false;
        if (navigator.platform.toUpperCase().indexOf('MAC') >= 0 || navigator.platform.toUpperCase().indexOf('IPAD') >= 0) {
            bool = true;
        }
        return bool;
    }
}
