import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Miembro } from '../models/miembro';

@Injectable({ providedIn: 'root' })
export class MiembroService {
  private apiUrl = 'http://localhost:5009/api/Miembros';

  constructor(private http: HttpClient) {}

  getMiembros(): Observable<Miembro[]> {
    return this.http.get<Miembro[]>(this.apiUrl);
  }

  addMiembro(miembro: Miembro): Observable<Miembro> {
    return this.http.post<Miembro>(this.apiUrl, miembro);
  }

  updateMiembro(miembro: Miembro): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${miembro.miembroId}`, miembro);
  }

  deleteMiembro(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
