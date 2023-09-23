import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { Route, RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import {
  JwtHelperService,
  JwtModule,
  JwtModuleOptions,
} from '@auth0/angular-jwt';
import { HttpRequestInterceptor } from './helpers/interceptors/http.interceptor';
import { AuthGuard } from './helpers/gurads/auth.guard';
import { HttpClientModule } from '@angular/common/http';
import { EmployeeLeaveRequestComponent } from './pages/employee-leave-request/employee-leave-request.component';
import { JwtInterceptor } from './helpers/interceptors/jwt.interceptor';
import { ManagerSubordinatesComponent } from './pages/manager-subordinates/manager-subordinates.component';

//all components routes
const routes: Route[] = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'LeaveRequest', component: EmployeeLeaveRequestComponent },
];

export function tokenGetter() {
  return localStorage.getItem('access_token');
}
const JWT_Module_Options: JwtModuleOptions = {
  config: {
    tokenGetter: tokenGetter,
    allowedDomains: ['localhost:7220'],
  },
};

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    EmployeeLeaveRequestComponent,
    ManagerSubordinatesComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
    JwtModule.forRoot(JWT_Module_Options),
  ],
  providers: [
    AuthGuard,
    HttpRequestInterceptor,
    JwtHelperService,
    JwtInterceptor,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
function GetToken() {
  throw new Error('Function not implemented.');
}
