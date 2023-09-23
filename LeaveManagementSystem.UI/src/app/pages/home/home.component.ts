import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  constructor(private jwtHelper: JwtHelperService, private router: Router) {}
  LeaveRequestFlag: boolean = true;
  isAuthenticated() {
    const token = localStorage.getItem('access_token');
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    } else {
      return false;
    }
  }
  public logOut = () => {
    localStorage.removeItem('access_token');
  };

  LeaveRequest() {
    this.LeaveRequestFlag = !this.LeaveRequestFlag;
  }
}
