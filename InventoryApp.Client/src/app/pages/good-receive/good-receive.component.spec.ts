import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoodReceiveComponent } from './good-receive.component';

describe('GoodReceiveComponent', () => {
  let component: GoodReceiveComponent;
  let fixture: ComponentFixture<GoodReceiveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GoodReceiveComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GoodReceiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
