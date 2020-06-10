import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SidelayoutComponent } from './Shared/Layouts/sidelayout/sidelayout.component';
import { HeaderComponent } from './Shared/Layouts/sidelayout/header/header.component';
import { SidemenuComponent } from './Shared/Layouts/sidelayout/sidemenu/sidemenu.component';
import { FooterComponent } from './Shared/Layouts/sidelayout/footer/footer.component';
import { LoginComponent } from './Features/Public/Login/Pages/login/login.component';
import { DashboardComponent } from './Features/Private/Dashboard/Pages/dashboard/dashboard.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { DashboardfilterComponent } from './Features/Private/Dashboard/Pages/dashboard/dashboardfilter/dashboardfilter.component';
import { DashboardgridComponent } from './Features/Private/Dashboard/Pages/dashboard/dashboardgrid/dashboardgrid.component';
import { DashboardtabsComponent } from './Features/Private/Dashboard/Pages/dashboard/dashboardtabs/dashboardtabs.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { DashboardStatisticComponent } from './Features/Private/Dashboard/Pages/dashboard/dashboard-statistic/dashboard-statistic.component';
@NgModule({
  declarations: [
    AppComponent,
    SidelayoutComponent,
    HeaderComponent,
    SidemenuComponent,
    FooterComponent,
    LoginComponent,
    DashboardComponent,
    DashboardfilterComponent,
    DashboardgridComponent,
    DashboardtabsComponent,
    DashboardStatisticComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    BsDatepickerModule.forRoot(),
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    CollapseModule.forRoot(),
    PaginationModule.forRoot(),
    TabsModule.forRoot(),
    AngularFontAwesomeModule,
  ],
  exports: [BsDropdownModule, TooltipModule, ModalModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
