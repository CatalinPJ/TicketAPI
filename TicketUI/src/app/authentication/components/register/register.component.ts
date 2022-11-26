import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  loginForm: any = {};

  buttonOptions: any = {
    text: 'Register',
    type: 'success',
    useSubmitBehavior: false,
  };

  constructor(
    private router: Router,
    private authService: AuthenticationService
  ) {}

  ngOnInit(): void {}

  onFormSubmit(e: any) {
    this.authService.register(this.loginForm).subscribe((o) => {
      this.router.navigate(['login']);
    });
  }
  navigateToLogin(e: any) {
    this.router.navigate(['login']);
  }
}
