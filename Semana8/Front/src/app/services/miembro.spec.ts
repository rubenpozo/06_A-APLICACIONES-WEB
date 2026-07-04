import { TestBed } from '@angular/core/testing';

import { Miembro } from './miembro';

describe('Miembro', () => {
  let service: Miembro;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Miembro);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
