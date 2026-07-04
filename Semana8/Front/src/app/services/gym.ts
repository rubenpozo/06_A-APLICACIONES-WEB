// src/app/services/gym.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// DTOs
export interface MiembroDto {
  miembroId: number;
  nombre: string;
  apellido: string;
}

export interface EntrenadorDto {
  entrenadorId: number;
  nombre: string;
  especialidad: string;
  miembros: MiembroDto[];
}

@Injectable({ providedIn: 'root' })
export class GymService {
  private apiEntrenadores = 'http://localhost:5000/api/entrenadores';
  private apiMiembros = 'http://localhost:5000/api/miembros';

  constructor(private http: HttpClient) {}

  // ==========================
  // Entrenadores
  // ==========================
  getEntrenadores(): Observable<EntrenadorDto[]> {
    return this.http.get<EntrenadorDto[]>(this.apiEntrenadores);
  }

  getEntrenador(id: number): Observable<EntrenadorDto> {
    return this.http.get<EntrenadorDto>(`${this.apiEntrenadores}/${id}`);
  }

  addEntrenador(entrenador: EntrenadorDto): Observable<EntrenadorDto> {
    return this.http.post<EntrenadorDto>(this.apiEntrenadores, entrenador);
  }

  updateEntrenador(entrenador: EntrenadorDto): Observable<void> {
    return this.http.put<void>(`${this.apiEntrenadores}/${entrenador.entrenadorId}`, entrenador);
  }

  deleteEntrenador(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiEntrenadores}/${id}`);
  }

  // ==========================
  // Miembros
  // ==========================
  getMiembros(): Observable<MiembroDto[]> {
    return this.http.get<MiembroDto[]>(this.apiMiembros);
  }

  getMiembro(id: number): Observable<MiembroDto> {
    return this.http.get<MiembroDto>(`${this.apiMiembros}/${id}`);
  }

  addMiembro(miembro: MiembroDto): Observable<MiembroDto> {
    return this.http.post<MiembroDto>(this.apiMiembros, miembro);
  }

  updateMiembro(miembro: MiembroDto): Observable<void> {
    return this.http.put<void>(`${this.apiMiembros}/${miembro.miembroId}`, miembro);
  }

  deleteMiembro(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiMiembros}/${id}`);
  }
}
