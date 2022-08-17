import { ToastrService } from 'ngx-toastr';
import { OrderService } from './../Shared/order.service';
import { Component, OnInit } from '@angular/core';
import { Drugs } from '../Models/drugs';
import { PharmaycartService } from '../Shared/pharmaycart.service';
import { Order } from '../Models/order';
import { MailToDoctorService } from '../Shared/mail-to-doctor.service';

@Component({
  selector: 'app-orderdetails',
  templateUrl: './orderdetails.component.html',
  styleUrls: ['./orderdetails.component.css']
})
export class OrderdetailsComponent implements OnInit {
 
  constructor(private order:PharmaycartService,
    private item:OrderService,
    private toaster:ToastrService,
    private mail:MailToDoctorService) 
    { }
Orders:Order[]=[];
drug:Drugs;
OrderUp:Order={
  orderId: 0,
  doctorId: '',
  drugId: 0,
  drugsName: '',
  drugPrice: 0,
  drugQuantity: 0,
  pickupDate: '',
  totalAmount: 0,
  isPicked: ''
}
drugUp:Drugs={
  drugId: 0,
  drugName: '',
  drugPrice: 0,
  drugQuantity: 0,
  mfdDate: 0,
  expDate: 0,
  supplierId: 0
}
  ngOnInit(): void {
    this.GetOrderDetails();
    
  }
  
  GetOrderDetails() {
    this.item.GetOrders().subscribe((data) => {
      for(let x of data){
        if(x.isPicked=="Hold"){
          this.Orders.push(x);
        }
      }      
    });
  }

  declineorder(order:Order){
   
    order.isPicked="Not Approved";
    this.item.UpdateOrder(order).subscribe((data)=>{
      
    this.toaster.success("Order Declined")
    location.reload();

    });


  }
  orderList:Order[]=[];
  confirmorder(order:Order){
    
    order.isPicked="Approved";
    this.item.UpdateOrder(order).subscribe((data)=>
    {
      this.orderList.push(order);
      this.mail.SendingMailByAdmin(this.orderList).subscribe(item=>{})
      console.log(data);
          
    }); 

    
      
   
    function delay(time: any) {
      return new Promise((resolve) => setTimeout(resolve, time));
    }

    delay(4000).then(() => console.log('ran after 1 second1 passed'));
   location.reload();

  }
  
  updateQuantity(order:Order){
    this.item.GetDrug(order.drugId).subscribe((data)=>
    {
      this.drug=data;
      
   
    if(this.drug.drugQuantity>order.drugQuantity)
    {
      console.log(this.drug.drugQuantity);
      
      this.drug.drugQuantity=this.drug.drugQuantity-order.drugQuantity;
      this.item.QuantityChange(this.drug).subscribe((data)=>
      {
        console.log(data);
       
      });
      this.confirmorder(order);
     
      this.toaster.success("Order Confirmed")
      this.toaster.success("Mail Sent")
     
         location.reload();
    }
    else
    {
      this.toaster.error("Unable to place the order");
    }
      
    });
  }
}
