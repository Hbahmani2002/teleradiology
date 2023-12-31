import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import { LoadingInterceptor } from './shared/interceptors/loading/loading-interceptor';
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
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { KosoperationsComponent } from './Features/Private/Operations/Pages/kosoperations/kosoperations.component';
import { KosfilterComponent } from './Features/Private/Operations/Pages/kosoperations/kosfilter/kosfilter.component';
import { KosgridComponent } from './Features/Private/Operations/Pages/kosoperations/kosgrid/kosgrid.component';
import { KostabsComponent } from './Features/Private/Operations/Pages/kosoperations/kostabs/kostabs.component';
import { KosstatisticComponent } from './Features/Private/Operations/Pages/kosoperations/kosstatistic/kosstatistic.component';
import { UserComponent } from './Features/Private/Definitions/Pages/user/user.component';
import { RoleComponent } from './Features/Private/Definitions/Pages/role/role.component';
import { KosdetailgridComponent } from './Features/Private/Operations/Pages/kosoperations/kostabs/kosdetailgrid/kosdetailgrid.component';
import { UserfilterComponent } from './Features/Private/Definitions/Pages/user/userfilter/userfilter.component';
import { UsergridComponent } from './Features/Private/Definitions/Pages/user/usergrid/usergrid.component';
import { UsertabsComponent } from './Features/Private/Definitions/Pages/user/usertabs/usertabs.component';
import { FilterComponent } from './Shared/Components/filter/filter.component';
import { GridtoolsComponent } from './Shared/Components/gridtools/gridtools.component';
import { RolegridComponent } from './Features/Private/Definitions/Pages/role/rolegrid/rolegrid.component';
import { RoletabsComponent } from './Features/Private/Definitions/Pages/role/roletabs/roletabs.component';
import { PageheaderComponent } from './Shared/Components/pageheader/pageheader.component';
import { EdituserComponent } from './Features/Private/Definitions/Modals/edituser/edituser.component';
import { ConfirmationdialogComponent } from './Shared/Modals/confirmationdialog/confirmationdialog.component';
import { RolefilterComponent } from './Features/Private/Definitions/Pages/role/rolefilter/rolefilter.component';
import { EditroleComponent } from './Features/Private/Definitions/Modals/editrole/editrole.component';
import { cookieService } from './Shared/Services/Util/cookieService';
import { httpService } from './Shared/Services/Util/httpService';
import { tokenService } from './Shared/Services/Util/tokenService';
import { ApiDataService } from './Shared/Services/Api/apiDataService';
import { NgxSpinnerModule } from 'ngx-spinner';
import { SelectDropDownModule } from 'ngx-select-dropdown'
import { LoginCheckActivate } from './Shared/Services/Guards/authorizationGuard';
import { authenticationDataService } from './Shared/Services/Data/authenticationDataService';
import { ToastrModule } from 'ngx-toastr';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { TestpageComponent } from './Features/Public/testpage/testpage.component';
import { userDataServices } from './Features/Private/Definitions/Services/userDataServices';
import { kosDataServices } from './Features/Private/Operations/Services/kosDataServices';
import { roleDataServices } from './Features/Private/Definitions/Services/roleDataServices';
import { KosdetailComponent } from './Features/Private/Operations/Pages/kosoperations/kostabs/kosdetail/kosdetail.component';
import { JobsComponent } from './Features/Private/Operations/Pages/jobs/jobs.component';
import { JobsfilterComponent } from './Features/Private/Operations/Pages/jobs/jobsfilter/jobsfilter.component';
import { JobsgridComponent } from './Features/Private/Operations/Pages/jobs/jobsgrid/jobsgrid.component';
import { jobDataServices } from './Features/Private/Operations/Services/jobDataServices';
import { GlobalErrorHandler } from './Shared/Services/ErrorHandling/GlobalErrorHandler';
import { SidetestComponent } from './Shared/Pages/sidetest/sidetest.component';
import { LogoutService } from './Shared/Services/Util/logoutService';
import { TeletipstmComponent } from './Features/Private/Operations/Pages/teletipstm/teletipstm.component';
import { StmfilterComponent } from './Features/Private/Operations/Pages/teletipstm/stmfilter/stmfilter.component';
import { StmgridComponent } from './Features/Private/Operations/Pages/teletipstm/stmgrid/stmgrid.component';
import { stmDataServices } from './Features/Private/Operations/Services/stmDataServices';
import { InputmodalComponent } from './Shared/Modals/inputmodal/inputmodal.component';
import { DicomViewerModule } from '../../projects/dicom-viewer/src/lib/dicom-viewer.module'


@NgModule({
  declarations: [
    AppComponent,
    SidelayoutComponent,
    HeaderComponent,
    SidemenuComponent,
    FooterComponent,
    LoginComponent,
    DashboardComponent,
    KosoperationsComponent,
    KosfilterComponent,
    KosgridComponent,
    KostabsComponent,
    KosstatisticComponent,
    UserComponent,
    RoleComponent,
    KosdetailgridComponent,
    UserfilterComponent,
    UsergridComponent,
    UsertabsComponent,
    FilterComponent,
    GridtoolsComponent,
    RolegridComponent,
    RoletabsComponent,
    PageheaderComponent,
    EdituserComponent,
    ConfirmationdialogComponent,
    RolefilterComponent,
    EditroleComponent,
    TestpageComponent,
    KosdetailComponent,
    JobsComponent,
    JobsfilterComponent,
    JobsgridComponent,
    SidetestComponent,
    TeletipstmComponent,
    StmfilterComponent,
    StmgridComponent,
    InputmodalComponent
  ],
  imports: [

    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    DicomViewerModule,
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    BsDatepickerModule.forRoot(),
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    CollapseModule.forRoot(),
    PaginationModule.forRoot(),
    TabsModule.forRoot(),
    ToastrModule.forRoot({ positionClass: 'toast-bottom-right'}),
    NgMultiSelectDropDownModule.forRoot(),
    AngularFontAwesomeModule,
    NgxSpinnerModule,
    SelectDropDownModule,
  ],
 
  exports:
    [
      BsDropdownModule,
      TooltipModule,
      ModalModule
    ],
  providers:
    [
      { provide: ErrorHandler, useClass: GlobalErrorHandler },

      { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
      CookieService,
      cookieService,
      httpService,
      tokenService,
      ApiDataService,
      LoginCheckActivate,
      authenticationDataService,
      userDataServices,
      kosDataServices,
      roleDataServices,
      jobDataServices,
      LogoutService,
      stmDataServices,
    ],
  entryComponents:
    [
      EditroleComponent,
      EdituserComponent,
      ConfirmationdialogComponent,
      InputmodalComponent
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
