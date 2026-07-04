import { TestBed } from '@angular/core/testing';

import { Jardineria } from './jardineria';

describe('Jardineria', () => {
  let service: Jardineria;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Jardineria);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
