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

  getDatasources() {
    return this.http.get<any>(`${this.apiUrl}/tickets/datasources`);
  }
}
