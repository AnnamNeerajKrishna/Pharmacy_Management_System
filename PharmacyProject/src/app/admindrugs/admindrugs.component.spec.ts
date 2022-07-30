import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmindrugsComponent } from './admindrugs.component';

describe('AdmindrugsComponent', () => {
  let component: AdmindrugsComponent;
  let fixture: ComponentFixture<AdmindrugsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdmindrugsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdmindrugsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
