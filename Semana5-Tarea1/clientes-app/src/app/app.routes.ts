import { Routes } from '@angular/router';
import { ListaComponent } from './clientes/lista/lista';
import { FormularioComponent } from './clientes/formulario/formulario';

export const routes: Routes = [
  { path: 'clientes', component: ListaComponent },
  { path: 'nuevo', component: FormularioComponent },
  { path: '', redirectTo: '/clientes', pathMatch: 'full' }
];

