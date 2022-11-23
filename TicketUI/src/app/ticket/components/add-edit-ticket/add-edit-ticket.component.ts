import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { isDefined } from 'src/app/_common/utils/utils';
import { TicketService } from '../../services/ticket.service';

@Component({
  selector: 'app-add-edit-ticket',
  templateUrl: './add-edit-ticket.component.html',
  styleUrls: ['./add-edit-ticket.component.scss'],
})
export class AddEditTicketComponent implements OnInit {
  ticket: any;
  title: string = '';
  editMode: boolean = false;

  ticketDatasources: any = {};

  constructor(
    private route: ActivatedRoute,
    private ticketService: TicketService
  ) {}

  async ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id !== null)
      this.ticket = await firstValueFrom(this.ticketService.getById(id));

    console.log(this.ticket);

    this.ticketDatasources = await firstValueFrom(
      this.ticketService.getDatasources()
    );

    console.log(this.ticketDatasources);

    this.editMode = isDefined(this.ticket);
    this.title = this.editMode === true ? 'Edit ticket' : 'Create ticket';
  }

  onSave() {
    console.log(this.ticket);
  }
}
