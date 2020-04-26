import { NgModule } from "@angular/core";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { RouterModule } from "@angular/router";
import { HttpModule } from "@angular/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { NgxSpinnerModule } from "ngx-spinner";

import { AppComponent } from "./app.component";
import { SidebarModule } from "./template/sidebar/sidebar.module";
import { FooterModule } from "./template/shared/footer/footer.module";
import { NavbarModule } from "./template/shared/navbar/navbar.module";
import { FixedpluginModule } from "./template/shared/fixedplugin/fixedplugin.module";
import { AdminLayoutComponent } from "./template/layouts/admin/admin-layout.component";
import { AuthLayoutComponent } from "./template/layouts/auth/auth-layout.component";

import { AppRoutes } from "./app.routing";
import { MaterialModule } from "./modules/material.module";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { MatConfirmDialogComponent } from "./template/mat-confirm-dialog/mat-confirm-dialog.component";
import { AuthInterceptor } from "./modules/auth/auth.interceptor";
import { AuthService } from "./services/auth.service";

@NgModule({
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule, //i had to add here too (instead just MobileControlModule) because PassWordMatch (CustomValidators) is not working
    MaterialModule,
    RouterModule.forRoot(AppRoutes, {
      useHash: true,
    }),
    HttpModule,
    HttpClientModule,
    MaterialModule,
    SidebarModule,
    NavbarModule,
    FooterModule,
    FixedpluginModule,
    NgxSpinnerModule,
  ],
  declarations: [
    MatConfirmDialogComponent,
    AppComponent,
    AdminLayoutComponent,
    AuthLayoutComponent,
  ],
  bootstrap: [AppComponent],
  entryComponents: [MatConfirmDialogComponent],
  //Here on Providers I`ll configure my HTTPInterceptor that will Catch the Requests and Add the Token - Note:
  //Interceptor needs to be Here on the Main-Module and cannot be set on the Assets or other Modules...
  providers: [
    AuthService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
})
export class AppModule {}
