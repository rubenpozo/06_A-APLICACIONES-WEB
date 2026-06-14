import { Component, OnInit, signal } from '@angular/core';
import { ClientesService, Cliente } from '../../services/clientes';

@Component({
  selector: 'app-lista-clientes',
  standalone: true,
  imports: [], // no necesitas CommonModule si usas @for
  templateUrl: './lista.html',
  styleUrls: ['./lista.css']
})
export class ListaComponent implements OnInit {
  clientes = signal<Cliente[]>([]);

  constructor(private clientesService: ClientesService) {}

  ngOnInit(): void {
    this.clientesService.getClientes().subscribe(data => {
      this.clientes.set(data);
    });
  }

  eliminar(id: number) {
    this.clientesService.eliminarCliente(id).subscribe(() => {
      this.clientes.set(this.clientes().filter(c => c.id !== id));
    });
  }
}

