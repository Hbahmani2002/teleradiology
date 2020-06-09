import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SidelayoutComponent } from './Shared/Layouts/sidelayout/sidelayout.component';
import { DashboardComponent } from './Features/Private/Dashboard/Pages/dashboard/dashboard.component';

const routes: Routes = [
  {
    path: '',
    component: SidelayoutComponent,
    children: [
      { path: '', component: DashboardComponent, pathMatch: 'full' }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
