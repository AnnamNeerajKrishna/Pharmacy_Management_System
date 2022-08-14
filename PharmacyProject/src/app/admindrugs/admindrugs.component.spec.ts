import { Drugs } from './../Models/drugs';
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmindrugsComponent } from './admindrugs.component';
import { Component } from '@angular/core';

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
  /* it('Available Drugs',()=>{
    //Drugs drug=new Drugs();

    let druglist=component.getAllDrugs();
    expect(component.getAllDrugs()).toBe(druglist)

  }); */
});
