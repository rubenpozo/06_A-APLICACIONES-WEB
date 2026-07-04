import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MiembrosList } from './miembros-list';

describe('MiembrosList', () => {
  let component: MiembrosList;
  let fixture: ComponentFixture<MiembrosList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MiembrosList],
    }).compileComponents();

    fixture = TestBed.createComponent(MiembrosList);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
