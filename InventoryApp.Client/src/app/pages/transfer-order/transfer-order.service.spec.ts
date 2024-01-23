import { TestBed } from '@angular/core/testing';

import { TransferOrderService } from './transfer-order.service';

describe('TransferOrderService', () => {
  let service: TransferOrderService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TransferOrderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
