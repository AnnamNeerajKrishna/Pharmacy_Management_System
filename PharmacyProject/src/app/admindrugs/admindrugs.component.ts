import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { PharmacyServiceService } from './../Shared/pharmacy-service.service';
import { Drugs } from './../Models/drugs';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admindrugs',
  templateUrl: './admindrugs.component.html',
  styleUrls: ['./admindrugs.component.css']
})
export class AdmindrugsComponent implements OnInit {
  public drugs:Drugs[]=[];
  Search:any;

  drugL:Drugs={
    drugId: 0,
    drugName: '',
    drugPrice: 0,
    drugQuantity: 0,
    expDate: 0,
    mfdDate: 0,
    supplierId: 0
  }

  constructor(private pharmacyService:PharmacyServiceService,private router:Router,private toaster:ToastrService) { }

  ngOnInit(): void {
    this.getAllDrugs();
    console.log(this.drugs);
  }
  getAllDrugs(){
    this.pharmacyService.getalldrugs()
    .subscribe(
      response=>{
        this.drugs=response;

  //     console.log(this.drugs);
      }

    );
  }
  onSubmit(){
  
    this.pharmacyService.AddDrugs(this.drugL)
    .subscribe(
      Response=>{
     
        this.router.navigate(['/admindrug']);
        
        this.getAllDrugs();   
         this.toaster.success("Drug was added");
    
      }
    )
    
    function delay(time: any) {
      return new Promise((resolve) => setTimeout(resolve, time));
    }

    delay(4000).then(() => console.log('ran after 1 second1 passed'));
  location.reload();
  }
  onDelete(id:Drugs){
    this.pharmacyService.deleteDrugs(id.drugId).subscribe(
      res=>{
        //this.drugs=this.drugs.filter(item=>item.drugId!==id);
        console.log(res);
        
        this.getAllDrugs();    
      }
    )
    this.toaster.success("Drug was Deleted");
    function delay(time: any) {
      return new Promise((resolve) => setTimeout(resolve, time));
    }

    delay(5000).then(() => console.log('ran after 1 second1 passed'));
    location.reload();
  }
  onUpdate(drug:Drugs){
    (this.drugL.drugId = drug.drugId);
    (this.drugL.drugName = drug.drugName);
    (this.drugL.drugPrice = drug.drugPrice);
    (this.drugL.drugQuantity = drug.drugQuantity);
    (this.drugL.expDate = drug.expDate);
  (this.drugL.mfdDate = drug.mfdDate);
    (this.drugL.supplierId = drug.supplierId);
  }
  
  updatedrug(drug:Drugs){
this.pharmacyService.updateDrug(drug).subscribe(
  res=>{
    //this.drugs=this.drugs.filter(item=>item.drugId!==id);
    console.log(res);
    
    this.getAllDrugs();    
  });
  this.toaster.success("Drug was Updated");
    function delay(time: any) {
      return new Promise((resolve) => setTimeout(resolve, time));
    }

    delay(4000).then(() => console.log('ran after 1 second1 passed'));
    location.reload();
  }

  onLogout(){
    localStorage.removeItem('token');
    this.router.navigateByUrl('/login');
  
  }
 


}
