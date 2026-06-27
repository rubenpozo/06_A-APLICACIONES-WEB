import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Jardineria {
  id?: number;
  planta: string;
  tipo: string;
  fechaSiembra: string;
}

@Injectable({
  providedIn: 'root'
})
export class JardineriaService {
  private apiUrl = 'https://localhost:7146/api/Jardineria';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Jardineria[]> {
    return this.http.get<Jardineria[]>(this.apiUrl);
  }

  create(jardineria: Jardineria): Observable<Jardineria> {
    return this.http.post<Jardineria>(this.apiUrl, jardineria);
  }
}
