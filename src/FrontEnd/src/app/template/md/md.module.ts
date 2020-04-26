
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { MdTableComponent } from './md-table/md-table.component';
import { MdChartComponent } from './md-chart/md-chart.component';

export interface DropdownLink {
  title: string;
  iconClass?: string;
  routerLink?: string;
}

export enum NavItemType {
  Sidebar = 1, // Only ever shown on sidebar
  NavbarLeft = 2, // Left-aligned icon-only link on navbar in desktop mode, shown above sidebar items on collapsed sidebar in mobile mode
  NavbarRight = 3 // Right-aligned link on navbar in desktop mode, shown above sidebar items on collapsed sidebar in mobile mode
}

export interface NavItem {
  type: NavItemType;
  title: string;
  routerLink?: string;
  iconClass?: string;
  numNotifications?: number;
  dropdownItems?: (DropdownLink | 'separator')[];
}

@NgModule({
  imports: [
    CommonModule,
    RouterModule
  ],
  declarations: [
    MdTableComponent,
    MdChartComponent
  ],
  exports: [
    MdTableComponent,
    MdChartComponent
  ]
})
export class MdModule { }
