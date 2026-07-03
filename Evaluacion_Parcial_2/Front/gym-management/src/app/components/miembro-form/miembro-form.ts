import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MiembroService } from '../../services/miembro.service';
import { Miembro } from '../../models/miembro';

@Component({
  selector: 'app-miembro-form',
  templateUrl: './miembro-form.html',
  styleUrls: ['./miembro-form.scss']
})
export class MiembroFormComponent implements OnInit {
  miembroForm!: FormGroup;

  constructor(private fb: FormBuilder, private miembroService: MiembroService) {}

  ngOnInit(): void {
    this.miembroForm = this.fb.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      fechaNacimiento: ['', Validators.required],
      tipoMembresia: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.miembroForm.valid) {
      const nuevoMiembro: Miembro = this.miembroForm.value;
      this.miembroService.addMiembro(nuevoMiembro).subscribe(() => {
        alert('Miembro registrado correctamente');
        this.miembroForm.reset();
      });
    }
  }
}

