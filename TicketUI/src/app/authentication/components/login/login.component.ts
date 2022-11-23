import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginForm: any = {};
  errorMessage: string | undefined;

  constructor(
    private router: Router,
    private authService: AuthenticationService
  ) {}

  ngOnInit(): void {}

  onFormSubmit(e: any) {
    console.log(this.loginForm);

    if (!this.loginForm.username) {
      this.errorMessage = 'Username cannot be empty';
      return;
    }

    if (!this.loginForm.password) {
      this.errorMessage = 'Password cannot be empty';
      return;
    }

    this.authService.login(this.loginForm).subscribe(
      (o) => {
        console.log(o);
        this.router.navigate(['']);
      },
      (err) => {
        this.errorMessage = err.error;
        console.log(err.error);
      }
    );
    //
  }

  navigateToRegister(e: any) {
    this.router.navigate(['../register']);
  }
}
