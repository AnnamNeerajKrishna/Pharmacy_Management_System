import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
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
  Search:any;
  


  constructor(private pharmacyService:PharmacyServiceService,
    private toaster :ToastrService,private router:Router) { }

  

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
    supplierId: 0,
    supplierName: '',
    emailID: '',
    contact: '',
    drugAvailable: ''
  }

  onSubmit(supplieradd:NgForm){
    this.pharmacyService.AddSupplier(supplieradd.value)
    .subscribe(
      Response=>{
        this.router.navigate(['/supplier']);
        this.toaster.success("Supplier was added");
        this.getAllSupplier();    
      }
    )
    
     function delay(time: any) {
      return new Promise((resolve) => setTimeout(resolve, time));
    }

    delay(4000).then(() => console.log('ran after 1 second1 passed'));
    //location.reload();
  }
  


  onDelete(id:Suppliers){
    this.pharmacyService.deleteSupplier(id.supplierId).subscribe(
      res=>{
        //this.drugs=this.drugs.filter(item=>item.drugId!==id);
        console.log(res);
        
        this.getAllSupplier();    
      }
    )
    this.toaster.success("Supplier was Deleted");
    function delay(time: any) {
      return new Promise((resolve) => setTimeout(resolve, time));
    }

    delay(5000).then(() => console.log('ran after 1 second1 passed'));
    window.location.reload();
  }
  onUpdate(supplier:Suppliers){
    (this.supplieradd.supplierId = supplier.supplierId);
    (this.supplieradd.supplierName = supplier.supplierName);
    (this.supplieradd.emailID = supplier.emailID);
    (this.supplieradd.contact = supplier.contact);
    (this.supplieradd.drugAvailable = supplier.drugAvailable);
  
  }
  updatesupplier(supplier:Suppliers){
    this.pharmacyService.updateSupplier(supplier).subscribe(
      res=>{
        //this.drugs=this.drugs.filter(item=>item.drugId!==id);
        console.log(res);
        
        this.getAllSupplier();    
      }
    );
    this.toaster.success("Supplier was Updated");
    function delay(time: any) {
      return new Promise((resolve) => setTimeout(resolve, time));
    }

    delay(5000).then(() => console.log('ran after 1 second1 passed'));
    location.reload();
  }
  onLogout(){
    localStorage.removeItem('token');
    this.router.navigateByUrl('/login');
  
  }

}
