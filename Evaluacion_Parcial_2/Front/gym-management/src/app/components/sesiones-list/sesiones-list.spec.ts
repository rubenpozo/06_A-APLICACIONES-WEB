import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SesionesList } from './sesiones-list';

describe('SesionesList', () => {
  let component: SesionesList;
  let fixture: ComponentFixture<SesionesList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SesionesList],
    }).compileComponents();

    fixture = TestBed.createComponent(SesionesList);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
