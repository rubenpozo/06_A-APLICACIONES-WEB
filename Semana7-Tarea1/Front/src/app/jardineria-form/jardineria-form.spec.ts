import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JardineriaForm } from './jardineria-form';

describe('JardineriaForm', () => {
  let component: JardineriaForm;
  let fixture: ComponentFixture<JardineriaForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JardineriaForm],
    }).compileComponents();

    fixture = TestBed.createComponent(JardineriaForm);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
