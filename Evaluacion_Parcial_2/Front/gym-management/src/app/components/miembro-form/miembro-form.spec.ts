import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MiembroForm } from './miembro-form';

describe('MiembroForm', () => {
  let component: MiembroForm;
  let fixture: ComponentFixture<MiembroForm>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MiembroForm],
    }).compileComponents();

    fixture = TestBed.createComponent(MiembroForm);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
