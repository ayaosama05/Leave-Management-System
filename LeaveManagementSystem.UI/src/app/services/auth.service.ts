import { Injectable } from '@angular/core';
import config from '../../assets/config/config.json';
import { LoginDto } from '../interfaces/LoginDto';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { EmployeeDto } from '../interfaces/EmployeeDto';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private returnUrl: string;
  API_URL = config.api.url + '/api/employees';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
  private userSubject: BehaviorSubject<EmployeeDto>;
  public user: Observable<EmployeeDto>;

  constructor(
    private router: Router,
    private http: HttpClient,
    private route: ActivatedRoute
  ) {
    this.userSubject = new BehaviorSubject<EmployeeDto>(
      JSON.parse(localStorage.getItem('employee') || '{}')
    );
    this.user = this.userSubject.asObservable();
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  public get userValue(): EmployeeDto {
    return this.userSubject.value;
  }

  login(body: LoginDto) {
    console.log(body);
    return this.http
      .post<EmployeeDto>(
        `${this.API_URL}/Login`,
        { username: body.username, password: body.password },
        this.httpOptions
      )
      .pipe(
        map((EmployeeDto) => {
          console.log(EmployeeDto);
          localStorage.setItem('access_token', EmployeeDto.token);
          localStorage.setItem('employee', JSON.stringify(EmployeeDto));
          this.router.navigate([this.returnUrl]);
        })
      );
  }

  getToken(): any | null {
    if (window.localStorage.getItem('access_token')) {
      const tokenResponse = {
        Token: window.localStorage.getItem('access_token') || '',
      };
      return tokenResponse;
    }
    return null;
  }

  logout() {
    window.localStorage.clear();
  }

  isLoggedIn(): boolean {
    let session = this.getToken();
    if (!session) {
      return false;
    }

    // check if token is expired
    const jwtToken = JSON.parse(
      atob((localStorage.getItem('access_token') || '{}').split('.')[1])
    );
    const tokenExpired = Date.now() > jwtToken.expires * 1000;

    return !tokenExpired;
  }
}
