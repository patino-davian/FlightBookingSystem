import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyBookingListComponent } from './my-booking-list.component';

describe('MyBookingListComponent', () => {
  let component: MyBookingListComponent;
  let fixture: ComponentFixture<MyBookingListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyBookingListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyBookingListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
