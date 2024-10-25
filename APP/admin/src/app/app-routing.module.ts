import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProfilesListComponent } from './profiles/profiles-list/profiles-list.component';
import { NewProfilesComponent } from './profiles/new-profiles/new-profiles.component';
import { ProfileDetailComponent } from './profiles/profile-detail/profile-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { authGuard } from './_guards/auth.guard';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { ProfileRegisterComponent } from './profiles/profile-register/profile-register.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ResetPwdComponent } from './account/reset-pwd/reset-pwd.component';
import { DocumentsComponent } from './catalagos/documents/documents.component';
import { HelpComponent } from './catalagos/help/help.component';
import { ParametersComponent } from './catalagos/parameters/parameters.component';
import { SamplesComponent } from './catalagos/samples/samples.component';
import { FrmUnderConstructionComponent } from './_forms/frm-under-construction/frm-under-construction.component';
import { AdminUsersComponent } from './account/admin-users/admin-users.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [authGuard],
    children: [
      {path: 'profiles', component: ProfilesListComponent, canActivate: [authGuard]},
      {path: 'newprofiles', component: NewProfilesComponent},
      {path: 'profile/:id', component: ProfileDetailComponent},
      {path: 'messages', component: MessagesComponent},    
    ]
  },
  //{path: '', component: HomeComponent},
  {path: 'documents', component: DocumentsComponent},
  {path: 'adminusers', component: AdminUsersComponent},
  {path: 'parameters', component: ParametersComponent},
  {path: 'samples', component: SamplesComponent},
  {path: 'help', component: HelpComponent},
  {path: 'resetpwd', component: ResetPwdComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'profile-register', component: ProfileRegisterComponent},
  {path: 'form/:formname', component: FrmUnderConstructionComponent},
  {path: 'not-found', component: NotFoundComponent},
  {path: 'server-error', component: ServerErrorComponent},
  {path: '**', component: NotFoundComponent, pathMatch: "full"},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
