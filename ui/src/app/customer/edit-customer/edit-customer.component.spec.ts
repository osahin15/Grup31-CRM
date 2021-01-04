import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCustomerComponent } from './edit-customer.component';

describe('EditCustomerComponent', () => {
  let component: EditCustomerComponent;
  let fixture: ComponentFixture<EditCustomerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
<<<<<<< HEAD
      declarations: [ EditCustomerComponent ]
    })
    .compileComponents();
=======
      declarations: [EditCustomerComponent]
    })
      .compileComponents();
>>>>>>> d2cdbdc48873cb6e2054c91476c9e900d3f7e97e
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditCustomerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
