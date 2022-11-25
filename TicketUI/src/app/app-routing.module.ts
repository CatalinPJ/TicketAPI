import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './authentication/components/login/login.component';
import { RegisterComponent } from './authentication/components/register/register.component';
import { AddEditTicketComponent } from './ticket/components/add-edit-ticket/add-edit-ticket.component';
import { TicketsComponent } from './ticket/components/tickets/tickets.component';
import { AuthGuard } from './_common/guards/auth.guard';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  { path: '', component: TicketsComponent, canActivate: [AuthGuard] },
  {
    path: 'add',
    component: AddEditTicketComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'create',
    component: AddEditTicketComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'edit/:id',
    component: AddEditTicketComponent,
    canActivate: [AuthGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
