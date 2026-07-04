import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Importa tus componentes
import { MiembrosListComponent } from './components/miembros-list/miembros-list';
import { EntrenadoresListComponent } from './components/entrenadores-list/entrenadores-list';
import { SesionesListComponent } from './components/sesiones-list/sesiones-list';
import { MiembroFormComponent } from './components/miembro-form/miembro-form';
import { EntrenadorFormComponent } from './components/entrenador-form/entrenador-form';

const routes: Routes = [
  { path: 'miembros', component: MiembrosListComponent },
  { path: 'miembros/nuevo', component: MiembroFormComponent },
  { path: 'entrenadores', component: EntrenadoresListComponent },
  { path: 'entrenadores/nuevo', component: EntrenadorFormComponent },
  { path: 'sesiones', component: SesionesListComponent },
  { path: '', redirectTo: '/miembros', pathMatch: 'full' }, // ruta por defecto
  { path: '**', redirectTo: '/miembros' } // ruta de fallback
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
