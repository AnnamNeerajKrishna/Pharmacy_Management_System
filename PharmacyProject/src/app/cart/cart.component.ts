import { Order } from './../Models/order';
import { Doctor } from './../Shared/doctor';
import { MailToDoctorService } from './../Shared/mail-to-doctor.service';
import { ToastrService } from 'ngx-toastr';
import { OrderService } from './../Shared/order.service';
import { PharmaycartService } from './../Shared/pharmaycart.service';
import { Router } from '@angular/router';
import { Drugs } from './../Models/drugs';
import { Component, OnInit } from '@angular/core';
//import { Order } from '../Models/order';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
DrugDetail:Drugs[]=[];
ordermail:Order[]=[];
doc:Doctor;
total=0
  constructor(private router:Router,
    private cart:PharmaycartService,
    private order:OrderService,
    private orderservice:OrderService,
    private email:MailToDoctorService
    ,private toaster:ToastrService) 
  { this.GetDrugData()}
user:any;

//Initial order
OrderL: Order = {
  orderId: 0,
  doctorId: '',
  drugId: 0,
  drugsName: '',
  drugPrice: 0,
  drugQuantity: 0,
  pickupDate: '',
  totalAmount: 0,
  isPicked: ''
};
docid:any=localStorage.getItem('Id');

  ngOnInit(): void {}
  GetDrugData(){
   // this.sumPrice=this.sumPrice+this.DrugDetail.
    this.DrugDetail=this.cart.GetCartData();
  }
  totalprice() {

    for (let x of this.DrugDetail) {

      this.total = this.total + x.drugQuantity * x.drugPrice;

    }

  }
 /*  totalprice(drug:Drugs[]){
    this.value=drug

    for(let j=0;j<drug.length;j++){
      this.total+=this.value[j].drugPrice;
    }

  } */
  AddOrders(druglst: any) {
    console.log(druglst);
    for (var x of druglst) {
      (this.OrderL.orderId = 0),
        (this.OrderL.doctorId = this.docid),
        (this.OrderL.drugId = x.drugId),
        (this.OrderL.drugsName = x.drugName),
        (this.OrderL.drugPrice = x.drugPrice),
        (this.OrderL.drugQuantity = x.drugQuantity),
        (this.OrderL.pickupDate = new Date().toISOString());
      this.OrderL.totalAmount = x.drugPrice * x.drugQuantity;
      this.OrderL.isPicked = "Hold";
     

      console.log(this.OrderL);

      this.orderservice.AddOrders(this.OrderL).subscribe((data) => {
        console.log(data);
        
        this.ordermail.push(data);
        console.log(this.ordermail);
        if(this.ordermail.length==druglst.length){
          this.email.SendMail(this.ordermail).subscribe((data)=>
          console.log(data)
          );
        }
      });
      
    }
    this.toaster.success('Your order was placed');
    this.toaster.success('Check Mail');

    //function to delay the code for 3 seconds to show the message
    function delay(time: any) {
      return new Promise((resolve) => setTimeout(resolve, time));
    }

    delay(4000).then(() => console.log('ran after 1 second1 passed'));
    
    //console.log(this.ordermail);
    
    
  }
  
 onLogout(){
    localStorage.removeItem('token');
    this.router.navigateByUrl('/login');
  
  }

}
