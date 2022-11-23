import { Component } from '@angular/core';
import { AuthenticationService } from './authentication/services/authentication.service';
import { isDefined } from './_common/utils/utils';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'TicketUI';

  user: any | undefined;

  constructor() {
    const userJson = localStorage.getItem('user');
    if (userJson !== null) this.user = JSON.parse(userJson);
    console.log(this.user);
  }
}
