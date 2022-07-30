import { PharmacyServiceService } from './../Shared/pharmacy-service.service';
import { Suppliers } from './../Models/suppliers';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-supplier',
  templateUrl: './supplier.component.html',
  styleUrls: ['./supplier.component.css']
})
export class SupplierComponent implements OnInit {

  public Suppliers:Suppliers[]=[];

  


  constructor(private pharmacyService:PharmacyServiceService) { }

  

  ngOnInit(): void {
    this.getAllSupplier()

  }
  getAllSupplier(){
    this.pharmacyService.getAllSupplierdata()
    .subscribe(
      response=>{
        this.Suppliers=response;
        console.log(response);
      }

    );
  }
  
  supplieradd : Suppliers={
    SupplierId: 0,
    SupplierName: '',
    EmailID: '',
    Contact: 0,
  }

  onSubmit(){
    this.pharmacyService.AddSupplier(this.supplieradd)
    .subscribe(
      Response=>{
        this.getAllSupplier();
        this.pharmacyService.AddSupplier(this.supplieradd);
      }
    )
  }


  DeleteSupplier(id:number){
    this.pharmacyService.deleteSupplier(id)
    .subscribe(
      Response=>{
        this.getAllSupplier();
      }
    );

  }

}
