import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Entrenador } from '../models/entrenador';

@Injectable({
  providedIn: 'root'
})
export class EntrenadorService {
  private apiUrl = 'http://localhost:5009/api/Entrenadores'; // tu endpoint de API

  constructor(private http: HttpClient) {}

  // Obtener todos los entrenadores
  getEntrenadores(): Observable<Entrenador[]> {
    return this.http.get<Entrenador[]>(this.apiUrl);
  }

  // Obtener un entrenador por ID
  getEntrenador(id: number): Observable<Entrenador> {
    return this.http.get<Entrenador>(`${this.apiUrl}/${id}`);
  }

  // Crear un nuevo entrenador
  addEntrenador(entrenador: Entrenador): Observable<Entrenador> {
    return this.http.post<Entrenador>(this.apiUrl, entrenador);
  }

  // Actualizar un entrenador existente
  updateEntrenador(id: number, entrenador: Entrenador): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, entrenador);
  }

  // Eliminar un entrenador
  deleteEntrenador(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
