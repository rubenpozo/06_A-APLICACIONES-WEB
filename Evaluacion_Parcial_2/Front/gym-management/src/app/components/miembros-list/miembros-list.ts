import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';   // <-- Importa CommonModule
import { MiembroService } from '../../services/miembro.service';
import { Miembro } from '../../models/miembro';

@Component({
  selector: 'app-miembros-list',
  standalone: true,
  imports: [CommonModule],   // <-- Aquí se incluye
  templateUrl: './miembros-list.html',
  styleUrls: ['./miembros-list.scss']
})
export class MiembrosListComponent implements OnInit {
  miembros: Miembro[] = [];

  constructor(private miembroService: MiembroService) {}

  ngOnInit(): void {
    this.miembroService.getMiembros().subscribe(data => {
      this.miembros = data;
      console.log(this.miembros); 
    });
  }
}


