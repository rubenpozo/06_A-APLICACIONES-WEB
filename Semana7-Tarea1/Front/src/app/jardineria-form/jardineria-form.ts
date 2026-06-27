import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { JardineriaService, Jardineria } from '../services/jardineria';
import { HttpClientModule } from '@angular/common/http';
import jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';

@Component({
  selector: 'app-jardineria-form',
  standalone: true,
  imports: [FormsModule, CommonModule, HttpClientModule],
  templateUrl: './jardineria-form.html'
})
export class JardineriaFormComponent implements OnInit {
  registros: Jardineria[] = [];
  nuevo: Jardineria = { planta: '', tipo: '', fechaSiembra: '' };

  constructor(private service: JardineriaService) {}

  ngOnInit(): void {
    this.cargarRegistros();
  }

  cargarRegistros() {
    this.service.getAll().subscribe(data => this.registros = data);
  }

  registrar() {
    this.service.create(this.nuevo).subscribe(() => {
      this.nuevo = { planta: '', tipo: '', fechaSiembra: '' };
      this.cargarRegistros();
    });
  }

  generarPDF() {
  const doc = new jsPDF();

  doc.setFontSize(16);
  doc.text('Registros de Jardinería', 14, 15);

  autoTable(doc, {
    head: [['ID', 'Planta', 'Tipo', 'Fecha Siembra']],
    body: this.registros.map(r => [
      r.id?.toString() ?? '',
      r.planta ?? '',
      r.tipo ?? '',
      r.fechaSiembra ? new Date(r.fechaSiembra).toLocaleDateString() : ''
    ]),
    startY: 25,
    theme: 'grid',
    headStyles: { fillColor: [0, 0, 0], textColor: [255, 255, 255] },
    styles: { halign: 'center' }
  });

  doc.save('jardineria.pdf');
}
}
