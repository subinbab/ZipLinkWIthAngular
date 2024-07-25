import { TestBed } from '@angular/core/testing';

import { UrlCLientService } from './url-client.service';

describe('UrlCLientService', () => {
  let service: UrlCLientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UrlCLientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
