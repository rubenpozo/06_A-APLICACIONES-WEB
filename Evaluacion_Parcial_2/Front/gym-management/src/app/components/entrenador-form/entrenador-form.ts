import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EntrenadorService } from '../../services/entrenador';
import { Entrenador } from '../../models/entrenador';

@Component({
  selector: 'app-entrenador-form',
  templateUrl: './entrenador-form.html',
  styleUrls: ['./entrenador-form.scss']
})
export class EntrenadorFormComponent implements OnInit {
  entrenadorForm!: FormGroup;

  constructor(private fb: FormBuilder, private entrenadorService: EntrenadorService) {}

  ngOnInit(): void {
    this.entrenadorForm = this.fb.group({
      nombre: ['', Validators.required],
      especialidad: ['', Validators.required],
      telefono: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  onSubmit(): void {
    if (this.entrenadorForm.valid) {
      const nuevoEntrenador: Entrenador = this.entrenadorForm.value;
      this.entrenadorService.addEntrenador(nuevoEntrenador).subscribe(() => {
        alert('Entrenador registrado correctamente');
        this.entrenadorForm.reset();
      });
    }
  }
}
