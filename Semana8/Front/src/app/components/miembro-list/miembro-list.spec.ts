import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MiembroList } from './miembro-list';

describe('MiembroList', () => {
  let component: MiembroList;
  let fixture: ComponentFixture<MiembroList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MiembroList],
    }).compileComponents();

    fixture = TestBed.createComponent(MiembroList);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
