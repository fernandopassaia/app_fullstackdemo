import { Routes } from "@angular/router";
import { AdminLayoutComponent } from "./template/layouts/admin/admin-layout.component";
import { AuthLayoutComponent } from "./template/layouts/auth/auth-layout.component";

export const AppRoutes: Routes = [
  {
    path: "",
    redirectTo: "dashboard",
    pathMatch: "full",
  },
  {
    path: "",
    component: AdminLayoutComponent,
    children: [
      {
        path: "",
        loadChildren: "./modules/appfullstackdemo.module#AppFullStackDemoModule",
      },
      {
        path: "",
        loadChildren: "./template/dashboard/dashboard.module#DashboardModule",
      },
    ],
  },
  {
    path: "",
    component: AuthLayoutComponent,
    children: [
      {
        path: "pages",
        loadChildren: "./template/pages/pages.module#PagesModule",
      },
    ],
  },
];
