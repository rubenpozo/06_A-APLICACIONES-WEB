// src/app/components/miembro-form/miembro-form.component.ts
import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GymService, MiembroDto, EntrenadorDto } from '../../services/gym';

@Component({
  selector: 'app-miembro-form',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './miembro-form.html',
  styleUrls: ['./miembro-form.css']
})
export class MiembroFormComponent implements OnInit {
  miembroForm: FormGroup;
  entrenadores: EntrenadorDto[] = [];

  constructor(private fb: FormBuilder, private service: GymService) {
    this.miembroForm = this.fb.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      entrenadorId: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.service.getEntrenadores().subscribe(data => this.entrenadores = data);
  }

  onSubmit(): void {
    if (this.miembroForm.valid) {
      const miembro: MiembroDto = {
        miembroId: 0,
        nombre: this.miembroForm.value.nombre,
        apellido: this.miembroForm.value.apellido
      };

      // Aquí enviamos el miembro con el entrenadorId seleccionado
      this.service.addMiembro({ ...miembro, entrenadorId: this.miembroForm.value.entrenadorId } as any)
        .subscribe({
          next: res => {
            alert(`Miembro ${res.nombre} creado con éxito`);
            this.miembroForm.reset();
          },
          error: err => console.error(err)
        });
    }
  }
}
