// src/app/components/entrenador-form/entrenador-form.component.ts
import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { GymService, EntrenadorDto, MiembroDto } from '../../services/gym';

@Component({
  selector: 'app-entrenador-form',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './entrenador-form.html',
  styleUrls: ['./entrenador-form.css']
})
export class EntrenadorFormComponent {
  entrenadorForm: FormGroup;

  constructor(private fb: FormBuilder, private service: GymService) {
    this.entrenadorForm = this.fb.group({
      nombre: ['', Validators.required],
      especialidad: ['', Validators.required],
      miembros: this.fb.array<FormGroup>([])   // tipado explícito
    });
  }

  // Tipamos el getter para que Angular sepa que son FormGroup[]
  get miembros(): FormArray<FormGroup> {
    return this.entrenadorForm.get('miembros') as FormArray<FormGroup>;
  }

  addMiembro(): void {
    this.miembros.push(
      this.fb.group({
        nombre: ['', Validators.required],
        apellido: ['', Validators.required]
      })
    );
  }

  removeMiembro(index: number): void {
    this.miembros.removeAt(index);
  }

  onSubmit(): void {
    if (this.entrenadorForm.valid) {
      const entrenador: EntrenadorDto = {
        entrenadorId: 0,
        nombre: this.entrenadorForm.value.nombre,
        especialidad: this.entrenadorForm.value.especialidad,
        miembros: this.entrenadorForm.value.miembros as MiembroDto[]
      };

      this.service.addEntrenador(entrenador).subscribe({
        next: res => {
          alert(`Entrenador ${res.nombre} creado con éxito`);
          this.entrenadorForm.reset();
          this.miembros.clear();
        },
        error: err => console.error(err)
      });
    }
  }
}
