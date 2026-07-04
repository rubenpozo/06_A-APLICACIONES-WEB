// src/app/services/miembro.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface MiembroDto {
  miembroId: number;
  nombre: string;
  apellido: string;
}

@Injectable({ providedIn: 'root' })
export class MiembroService {
  private apiUrl = 'http://localhost:5000/api/miembros';

  constructor(private http: HttpClient) {}

  getMiembros(): Observable<MiembroDto[]> {
    return this.http.get<MiembroDto[]>(this.apiUrl);
  }
}

