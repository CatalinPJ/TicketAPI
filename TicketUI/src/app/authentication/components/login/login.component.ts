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

  buttonOptions: any = {
    text: 'Login',
    type: 'success',
    useSubmitBehavior: true,
  };

  constructor(
    private router: Router,
    private authService: AuthenticationService
  ) {}

  ngOnInit(): void {}

  onFormSubmit(e: any) {
    console.log(this.loginForm);
    this.authService.login(this.loginForm).subscribe(
      (o) => {
        console.log(o);
        this.router.navigate(['../tickets']);
      },
      (err) => {
        console.log(err.error);
      }
    );
    //
  }
}
