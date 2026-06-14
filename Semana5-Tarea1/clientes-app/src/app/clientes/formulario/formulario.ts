import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ClientesService, Cliente } from '../../services/clientes';

@Component({
  selector: 'app-formulario-cliente',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './formulario.html',
  styleUrls: ['./formulario.css']
})
export class FormularioComponent {
  cliente = signal<Cliente>({
    id: 0,
    nombre: '',
    apellido: '',
    cedula: '',
    ciudad: '',
    telefono: ''
  });

  mensaje = signal<string | null>(null);

  constructor(private clientesService: ClientesService) {}

  guardar() {
    this.clientesService.crearCliente(this.cliente()).subscribe({
      next: () => {
        this.mensaje.set('Cliente creado exitosamente ✅');
        this.cliente.set({ id: 0, nombre: '', apellido: '', cedula: '', ciudad: '', telefono: '' });
      },
      error: () => {
        this.mensaje.set('❌ Error al crear el cliente');
      }
    });
  }
}

