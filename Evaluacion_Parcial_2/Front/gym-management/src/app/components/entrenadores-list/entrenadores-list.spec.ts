import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EntrenadoresList } from './entrenadores-list';

describe('EntrenadoresList', () => {
  let component: EntrenadoresList;
  let fixture: ComponentFixture<EntrenadoresList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EntrenadoresList],
    }).compileComponents();

    fixture = TestBed.createComponent(EntrenadoresList);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
