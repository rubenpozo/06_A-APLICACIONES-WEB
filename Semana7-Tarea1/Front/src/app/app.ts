import { Component } from '@angular/core';
import { JardineriaFormComponent } from './jardineria-form/jardineria-form';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [JardineriaFormComponent],
  template: `<app-jardineria-form></app-jardineria-form>`
})
export class AppComponent {}

