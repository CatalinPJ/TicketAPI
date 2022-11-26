import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class TicketService {
  private apiUrl: string | undefined;

  constructor(private http: HttpClient) {
    this.apiUrl = environment.apiUrl;
  }

  getAll() {
    return this.http.get<any[]>(`${this.apiUrl}/tickets`);
  }

  getById(id: string) {
    return this.http.get<any>(`${this.apiUrl}/tickets/${id}`);
  }

  create(ticket: any) {
    return this.http.post(`${this.apiUrl}/tickets`, ticket);
  }

  update(ticket: any) {
    return this.http.put(`${this.apiUrl}/tickets`, ticket);
  }

  close(id: string) {
    return this.http.put(`${this.apiUrl}/tickets/close?id=${id}`, {});
  }

  getDatasources() {
    return this.http.get<any>(`${this.apiUrl}/tickets/datasources`);
  }
}
