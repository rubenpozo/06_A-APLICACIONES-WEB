import { Routes } from '@angular/router';
import { MiembrosListComponent } from './components/miembros-list/miembros-list';
import { EntrenadoresListComponent } from './components/entrenadores-list/entrenadores-list';
import { SesionesListComponent } from './components/sesiones-list/sesiones-list';
import { MiembroFormComponent } from './components/miembro-form/miembro-form';
import { EntrenadorFormComponent } from './components/entrenador-form/entrenador-form';

export const routes: Routes = [
  { path: 'miembros', component: MiembrosListComponent },
  { path: 'miembros/nuevo', component: MiembroFormComponent },
  { path: 'entrenadores', component: EntrenadoresListComponent },
  { path: 'entrenadores/nuevo', component: EntrenadorFormComponent },
  { path: 'sesiones', component: SesionesListComponent },
  { path: '', redirectTo: '/miembros', pathMatch: 'full' },
  { path: '**', redirectTo: '/miembros' }
];

