import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoodIssueComponent } from './good-issue.component';

describe('GoodIssueComponent', () => {
  let component: GoodIssueComponent;
  let fixture: ComponentFixture<GoodIssueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GoodIssueComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GoodIssueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
