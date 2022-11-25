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
  ticket: any = {
    priority: {
      name: '',
    },
    serviceType: {
      name: '',
    },
    status: {
      name: '',
    },
    type: {
      name: '',
    },
  };
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
      var t = await firstValueFrom(this.ticketService.getById(id));

    if (isDefined(t)) {
      this.ticket = t;
    }
    console.log(this.ticket);

    this.ticketDatasources = await firstValueFrom(
      this.ticketService.getDatasources()
    );

    console.log(this.ticketDatasources);

    this.editMode = isDefined(this.ticket.id);
    this.title = this.editMode === true ? 'Edit ticket' : 'Create ticket';
  }

  onSave() {
    console.log(this.ticket);
    if (this.ticket.id) {
      this.ticketService.update(this.ticket).subscribe((o) => {
        console.log(this.ticket);
      });
    } else {
      this.ticketService.create(this.ticket).subscribe((o) => {
        console.log(this.ticket);
      });
    }
  }
}
