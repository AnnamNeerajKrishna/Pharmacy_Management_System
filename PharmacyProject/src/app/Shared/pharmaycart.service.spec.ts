import { TestBed } from '@angular/core/testing';

import { PharmaycartService } from './pharmaycart.service';

describe('PharmaycartService', () => {
  let service: PharmaycartService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PharmaycartService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
