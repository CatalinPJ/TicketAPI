import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TicketService } from '../../services/ticket.service';

@Component({
  selector: 'app-tickets',
  templateUrl: './tickets.component.html',
  styleUrls: ['./tickets.component.scss'],
})
export class TicketsComponent implements OnInit {
  tickets$: any;

  constructor(private ticketService: TicketService, private router: Router) {}

  ngOnInit(): void {
    this.tickets$ = this.ticketService.getAll();
  }

  goToEditPage(e: any) {
    this.router.navigate([`edit/${e.id}`]);
  }
}
