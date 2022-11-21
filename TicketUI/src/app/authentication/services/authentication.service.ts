import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { off } from 'devextreme/events';
import { map, of, switchMap } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  private apiUrl: string | undefined;
  private user: any | undefined;

  constructor(private http: HttpClient) {
    this.apiUrl = environment.apiUrl;
  }

  login(loginForm: any) {
    return this.http
      .post(`${this.apiUrl}/authentication/login`, loginForm)
      .pipe(
        map((o) => {
          this.user = o;
          return this.user;
        })
      );
  }

  register(loginForm: any) {
    return this.http.post(`${this.apiUrl}/authentication/register`, loginForm);
  }

  isLoggedIn() {
    return this.user !== undefined;
  }
}
