// src/app/components/miembro-list/miembro-list.component.ts
import { Component, OnInit } from '@angular/core';
import { MiembroService, MiembroDto } from '../../services/miembro';

@Component({
  selector: 'app-miembro-list',
  standalone: true,
  imports: [], // no necesitas CommonModule si usas @for
  templateUrl: './miembro-list.html',
  styleUrls: ['./miembro-list.css']
})
export class MiembroListComponent implements OnInit {
  miembros: MiembroDto[] = [];

  constructor(private service: MiembroService) {}

  ngOnInit(): void {
    this.service.getMiembros().subscribe(data => this.miembros = data);
  }
}
