import { TestBed } from '@angular/core/testing';

import { GoodReceiveService } from './good-receive.service';

describe('GoodReceiveService', () => {
  let service: GoodReceiveService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GoodReceiveService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
