import { TestBed } from '@angular/core/testing';

import { GoodIssueService } from './good-issue.service';

describe('GoodIssueService', () => {
  let service: GoodIssueService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GoodIssueService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
