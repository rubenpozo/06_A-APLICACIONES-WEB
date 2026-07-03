import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sesiones-list',
  templateUrl: './sesiones-list.html',
  styleUrls: ['./sesiones-list.scss']
})
export class SesionesListComponent implements OnInit {
  sesiones: any[] = [];

  constructor() {}

  ngOnInit(): void {
    // Aquí luego llamas al servicio para cargar sesiones
  }
}

