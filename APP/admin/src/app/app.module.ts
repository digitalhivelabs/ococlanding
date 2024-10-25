import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NavComponent } from './nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { NewProfilesComponent } from './profiles/new-profiles/new-profiles.component';
import { ProfileDetailComponent } from './profiles/profile-detail/profile-detail.component';
import { ProfilesListComponent } from './profiles/profiles-list/profiles-list.component';
import { MessagesComponent } from './messages/messages.component';
import { SharedModule } from './_modules/shared.module';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { ProfileRegisterComponent } from './profiles/profile-register/profile-register.component';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { DatePickerComponent } from './_forms/date-picker/date-picker.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ResetPwdComponent } from './account/reset-pwd/reset-pwd.component';
import { UsersApprovalsComponent } from './main/users-approvals/users-approvals.component';
import { SamplesComponent } from './catalagos/samples/samples.component';
import { ParametersComponent } from './catalagos/parameters/parameters.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { FooterComponent } from './footer/footer.component';
import { DocumentsComponent } from './catalagos/documents/documents.component';
import { HelpComponent } from './catalagos/help/help.component';
import { HeaderInterceptor } from './_interceptors/header.interceptor';
import { FrmUnderConstructionComponent } from './_forms/frm-under-construction/frm-under-construction.component';
import { SpecimensReportComponent } from './mainComponents/specimens-report/specimens-report.component';
import { SpecimenSummaryComponent } from './mainComponents/specimen-summary/specimen-summary.component';
import { SpecimenChartsComponent } from './mainComponents/specimen-charts/specimen-charts.component';
import { AdminUsersComponent } from './account/admin-users/admin-users.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    NewProfilesComponent,
    ProfileDetailComponent,
    ProfilesListComponent,
    MessagesComponent,
    NotFoundComponent,
    ServerErrorComponent,
    ProfileRegisterComponent,
    TextInputComponent,
    DatePickerComponent,
    DashboardComponent,
    ResetPwdComponent,
    UsersApprovalsComponent,
    SamplesComponent,
    ParametersComponent,
    SidebarComponent,
    FooterComponent,
    DocumentsComponent,
    HelpComponent,
    FrmUnderConstructionComponent,
    SpecimensReportComponent,
    SpecimenSummaryComponent,
    SpecimenChartsComponent,
    AdminUsersComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatSidenavModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    { provide: HTTP_INTERCEPTORS, useClass: HeaderInterceptor, multi: true},
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
