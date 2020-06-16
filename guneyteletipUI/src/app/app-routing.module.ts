import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SidelayoutComponent } from './Shared/Layouts/sidelayout/sidelayout.component';
import { DashboardComponent } from './Features/Private/Dashboard/Pages/dashboard/dashboard.component';
import { KosoperationsComponent } from './Features/Private/Operations/Pages/kosoperations/kosoperations.component';
import { UserComponent } from './Features/Private/Definitions/Pages/user/user.component';
import { RoleComponent } from './Features/Private/Definitions/Pages/role/role.component';
import { LoginComponent } from './Features/Public/Login/Pages/login/login.component';

import { LoginCheckActivate } from './Shared/Services/Guards/authorizationGuard';
import { TestpageComponent } from './Features/Public/testpage/testpage.component';
const routes: Routes = [
  {
    path: '',
    component: SidelayoutComponent,
    canActivate: [LoginCheckActivate],
    children: [
      { path: '', component: DashboardComponent, pathMatch: 'full' },
      { path: 'operations/kos', component: KosoperationsComponent, pathMatch: 'full' },
      { path: 'definitions/user', component: UserComponent, pathMatch: 'full' },
      { path: 'definitions/role', component: RoleComponent, pathMatch: 'full' },
      { path: 'gt_test', component: TestpageComponent, pathMatch: 'full' },
    ]
  },
  {
    path: 'login',
    component: LoginComponent

  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
