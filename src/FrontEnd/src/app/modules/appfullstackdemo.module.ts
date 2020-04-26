import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
//import { AdminLayoutRoutes } from 'app/template/admin-layout/admin-layout.routing';
import { RouterModule } from "@angular/router";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";

import { IConfig, NgxMaskModule } from "ngx-mask"; //for ngmask
export const options: Partial<IConfig> | (() => Partial<IConfig>) = {};

import { EmployeeComponent } from "../employee/employee.component";
import { EmployeeCuComponent } from "../employee/employee-cu/employee-cu.component";
import { EmployeeListComponent } from "../employee/employee-list/employee-list.component";

//import { AdminLayoutModule } from '../template/admin-layout/admin-layout.module';
import { MaterialModule } from "./material.module";
import { DevicesGroupsComponent } from "../devices-groups/devices-groups.component";
import { DeviceModelComponent } from "../devices-groups/devicemodel/devicemodel.component";
import { DeviceModelCuComponent } from "../devices-groups/devicemodel/devicemodel-cu/devicemodel-cu.component";
import { DeviceModelListComponent } from "../devices-groups/devicemodel/devicemodel-list/devicemodel-list.component";
import { ManufacturerComponent } from "../devices-groups/manufacturer/manufacturer.component";
import { ManufacturerCuComponent } from "../devices-groups/manufacturer/manufacturer-cu/manufacturer-cu.component";
import { ManufacturerListComponent } from "../devices-groups/manufacturer/manufacturer-list/manufacturer-list.component";
import { ForbiddenComponent } from "./auth/forbidden/forbidden.component";
import { ForbiddenMessageComponent } from "./auth/forbidden/forbiddenmessage/forbiddenmessage.component";
import { EquipmentComponent } from "../equipment/equipment.component";
import { EquipmentCuComponent } from "../equipment/equipment-cu/equipment-cu.component";
import { EquipmentListComponent } from "../equipment/equipment-list/equipment-list.component";
import { NumberPickerModule } from "ng-number-picker";
import { EnumDescriber } from "../shared/enum-describer.service";
import { AppFullStackDemoRoutes } from "./appfullstackdemo.routing";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AppFullStackDemoRoutes), //My File of Rotes
    FormsModule,
    ReactiveFormsModule, //i had to change from MobileControlModule to AppModule (main) because if not, Custom-Validators is not working
    //AdminLayoutModule, //I need to import AdminLayout module, because i need DashBoard that it exports
    MaterialModule, //My containner of Material Module components
    NumberPickerModule, //for the numberpicker (company screen > hours equipment not seen)
    NgxMaskModule.forRoot(options), //to MASK on inputs, like telephone    
  ],
  declarations: [
    ForbiddenComponent,
    ForbiddenMessageComponent,
    // Modules from the Real system
    EmployeeComponent,
    EmployeeCuComponent,
    EmployeeListComponent,

    // Groups of Devices
    DevicesGroupsComponent,
    DeviceModelComponent,
    DeviceModelCuComponent,
    DeviceModelListComponent,
    ManufacturerComponent,
    ManufacturerCuComponent,
    ManufacturerListComponent,

    EquipmentComponent,
    EquipmentCuComponent,
    EquipmentListComponent,
    EnumDescriber,
  ],
  //to open in a Modal (be injected) needs to be here in entry
  entryComponents: [
    DeviceModelCuComponent,
    ManufacturerCuComponent,
    EmployeeCuComponent,
  ],
})
export class AppFullStackDemoModule { }