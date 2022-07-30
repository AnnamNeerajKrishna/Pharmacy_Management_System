import { PharmacyServiceService } from './../Shared/pharmacy-service.service';
import { Drugs } from './../Models/drugs';
import { LoginService } from './../Shared/login.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admindrugs',
  templateUrl: './admindrugs.component.html',
  styleUrls: ['./admindrugs.component.css']
})
export class AdmindrugsComponent implements OnInit {
  public drugs:Drugs[]=[];

  drugL:Drugs={
    DrugId: 0,
    DrugName: '',
    DrugPrice: 0,
    DrugQuantity: 0,
    ExpDate: 0,
    MfdDate: 0,
    SupplierId: 0
  }

  constructor(private pharmacyService:PharmacyServiceService) { }

  ngOnInit(): void {
    this.getAllDrugs();

  }
  getAllDrugs(){
    this.pharmacyService.getalldrugs()
    .subscribe(
      response=>{
        this.drugs=response;
        console.log(response);
      }

    );
  }

  onSubmit(){
    console.log(this.drugL);
    this.pharmacyService.AddDrugs(this.drugL)
    .subscribe(
      Response=>{
        console.log(Response);
        console.log(this.drugL);
        this.getAllDrugs();
      
        
      }
    )
  }

}
