import { Component } from '@angular/core';
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
  }
}
