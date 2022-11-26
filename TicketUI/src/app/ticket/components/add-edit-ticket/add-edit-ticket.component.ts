import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { isDefined } from 'src/app/_common/utils/utils';
import { TicketService } from '../../services/ticket.service';

@Component({
  selector: 'app-add-edit-ticket',
  templateUrl: './add-edit-ticket.component.html',
  styleUrls: ['./add-edit-ticket.component.scss'],
})
export class AddEditTicketComponent implements OnInit {
  ticket: any = {};
  title: string = '';
  editMode: boolean = false;

  ticketDatasources: any = {};

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private ticketService: TicketService
  ) {}

  async ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id !== null)
      var ticket = await firstValueFrom(this.ticketService.getById(id));

    if (isDefined(ticket)) {
      this.ticket = ticket;
    }

    this.ticketDatasources = await firstValueFrom(
      this.ticketService.getDatasources()
    );

    this.editMode = isDefined(this.ticket.id);
    this.title = this.editMode === true ? 'Edit ticket' : 'Create ticket';
  }

  onSave() {
    if (this.ticket.id) {
      this.ticketService.update(this.ticket).subscribe((o) => {
        this.router.navigate([``]);
      });
    } else {
      this.ticketService.create(this.ticket).subscribe((o) => {
        this.router.navigate([``]);
      });
    }
  }
}
