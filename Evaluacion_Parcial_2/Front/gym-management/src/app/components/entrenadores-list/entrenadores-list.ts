import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-entrenadores-list',
  templateUrl: './entrenadores-list.html',
  styleUrls: ['./entrenadores-list.scss']
})
export class EntrenadoresListComponent implements OnInit {
  entrenadores: any[] = [];

  constructor() {}

  ngOnInit(): void {
    // Aquí luego llamas al servicio para cargar entrenadores
  }
}

