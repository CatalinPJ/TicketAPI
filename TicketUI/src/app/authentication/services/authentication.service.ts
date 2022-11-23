import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { isDefined } from 'src/app/_common/utils/utils';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  private apiUrl: string | undefined;
  private user: any | undefined;

  constructor(private http: HttpClient) {
    this.user = localStorage.getItem('user');
    this.apiUrl = environment.apiUrl;
  }

  login(loginForm: any) {
    return this.http
      .post(`${this.apiUrl}/authentication/login`, loginForm)
      .pipe(
        map((o) => {
          this.user = o;
          localStorage.setItem('user', JSON.stringify(this.user));
          return this.user;
        })
      );
  }

  register(loginForm: any) {
    return this.http.post(`${this.apiUrl}/authentication/register`, loginForm);
  }

  isLoggedIn() {
    return isDefined(this.user);
  }
}
