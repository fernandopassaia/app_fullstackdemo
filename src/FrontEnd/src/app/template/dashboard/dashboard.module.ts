import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { MdModule } from "../md/md.module";
import { DashboardComponent } from "./dashboard.component";
import { DashboardRoutes } from "./dashboard.routing";
import { MaterialModule } from "src/app/modules/material.module";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(DashboardRoutes),
    FormsModule,
    MdModule,
    MaterialModule,
  ],
  declarations: [DashboardComponent],
  exports: [
    //I'm exporting DashBoard in this module, and this module will be imported by my MobileControlModule that also need to use Dashboard
    DashboardComponent,
  ],
})
export class DashboardModule { }
