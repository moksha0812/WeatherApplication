import { TestBed } from '@angular/core/testing';

import { WatherService } from './weather.service';

describe('WatherService', () => {
  let service: WatherService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WatherService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
