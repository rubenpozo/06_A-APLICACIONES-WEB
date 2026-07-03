import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// Importa tus componentes standalone
import { MiembrosListComponent } from './components/miembros-list/miembros-list';
import { EntrenadoresListComponent } from './components/entrenadores-list/entrenadores-list';
import { SesionesListComponent } from './components/sesiones-list/sesiones-list';
import { MiembroFormComponent } from './components/miembro-form/miembro-form';
import { EntrenadorFormComponent } from './components/entrenador-form/entrenador-form';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MiembrosListComponent,
    EntrenadoresListComponent,
    SesionesListComponent,
    MiembroFormComponent,
    EntrenadorFormComponent
  ],
  template: `
    <div class="container mt-4">
      <h1 class="mb-4">Gym Management</h1>
      <router-outlet></router-outlet>
    </div>
  `
})
export class AppComponent {}
