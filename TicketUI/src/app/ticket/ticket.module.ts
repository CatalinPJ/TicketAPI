import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TicketsComponent } from './components/tickets/tickets.component';
import { SharedModule } from '../_common/shared.module';
import { AddEditTicketComponent } from './components/add-edit-ticket/add-edit-ticket.component';



@NgModule({
  declarations: [
    TicketsComponent,
    AddEditTicketComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class TicketModule { }
