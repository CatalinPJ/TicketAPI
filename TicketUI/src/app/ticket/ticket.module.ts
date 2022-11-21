import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TicketsComponent } from './components/tickets/tickets.component';
import { SharedModule } from '../_common/shared.module';



@NgModule({
  declarations: [
    TicketsComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class TicketModule { }
