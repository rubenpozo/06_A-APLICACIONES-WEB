import { Routes } from '@angular/router';
import { MiembroListComponent } from './components/miembro-list/miembro-list';
import { MiembroFormComponent } from './components/miembro-form/miembro-form';
import { EntrenadorFormComponent } from './components/entrenador-form/entrenador-form';

export const routes: Routes = [
  { path: 'miembros', component: MiembroListComponent },
  { path: 'miembros/nuevo', component: MiembroFormComponent },
  { path: 'entrenadores/nuevo', component: EntrenadorFormComponent },
  { path: '', redirectTo: '/miembros', pathMatch: 'full' }
];
