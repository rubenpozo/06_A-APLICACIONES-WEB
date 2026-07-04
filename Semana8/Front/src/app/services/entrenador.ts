// src/app/services/entrenador.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Entrenador {
  entrenadorId: number;
  nombre: string;
  especialidad: string;
  miembros?: Miembro[];
}

export interface Miembro {
  miembroId: number;
  nombre: string;
  apellido: string;
  entrenadorId: number;
}

@Injectable({ providedIn: 'root' })
export class EntrenadorService {
  private apiUrl = 'http://localhost:5000/api/entrenadores';

  constructor(private http: HttpClient) {}

  getEntrenadores(): Observable<Entrenador[]> {
    return this.http.get<Entrenador[]>(this.apiUrl);
  }

  addEntrenador(entrenador: Entrenador): Observable<Entrenador> {
    return this.http.post<Entrenador>(this.apiUrl, entrenador);
  }

  updateEntrenador(entrenador: Entrenador): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${entrenador.entrenadorId}`, entrenador);
  }

  deleteEntrenador(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
