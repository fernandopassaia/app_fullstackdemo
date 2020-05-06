import { Routes } from "@angular/router";
import { AuthGuard } from "./auth/auth.guard";
import { ForbiddenComponent } from "./auth/forbidden/forbidden.component";
import { UserComponent } from "../pages/user/user.component";
import { ManufacturerComponent } from "../pages/manufacturer/manufacturer.component";
import { DeviceModelComponent } from "../pages/devicemodel/devicemodel.component";
//import { EquipmentComponent } from "../equipment/equipment.component";

export const AppFullStackDemoRoutes: Routes = [
  //custom maps routes made by Fernando
  { path: "forbidden", component: ForbiddenComponent },

  //Note: I can have a Client-Side Role Verification, in this case i Have this "".Screen" roles, that will be done on
  //Client side, so this is a "First-level" Authorization, before API, and i will check if LoggedUser can se a Screen.
  //The second level will be done on the API side, on the Api-URL, by the Tag [Authorization] and corresponding Claim

  {
    path: "user",
    component: UserComponent,
    canActivate: [AuthGuard],
    data: { permittedRoles: ["user"] },
  },
  {
    path: "manufacturer",
    component: ManufacturerComponent,
    canActivate: [AuthGuard],
    data: { permittedRoles: ["manufacturer"] },
  },
  {
    path: "devicemodel",
    component: DeviceModelComponent,
    canActivate: [AuthGuard],
    data: { permittedRoles: ["devicemodel"] },
  },
];
