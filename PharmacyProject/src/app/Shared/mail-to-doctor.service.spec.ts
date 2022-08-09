import { TestBed } from '@angular/core/testing';

import { MailToDoctorService } from './mail-to-doctor.service';

describe('MailToDoctorService', () => {
  let service: MailToDoctorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MailToDoctorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
