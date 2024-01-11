import { TestBed } from '@angular/core/testing';

import { AddEditWarehouseService } from './add-edit-warehouse.service';

describe('AddEditWarehouseService', () => {
  let service: AddEditWarehouseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddEditWarehouseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
