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

@NgModule({
  declarations: [
    AppComponent,
    SidelayoutComponent,
    HeaderComponent,
    SidemenuComponent,
    FooterComponent,
    LoginComponent,
    DashboardComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot()
  ],
  exports: [BsDropdownModule, TooltipModule, ModalModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
