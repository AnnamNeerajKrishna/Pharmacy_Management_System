import { ToastrService } from 'ngx-toastr';
import { OrderService } from './../Shared/order.service';
import { Component, OnInit } from '@angular/core';
import { Drugs } from '../Models/drugs';
import { PharmaycartService } from '../Shared/pharmaycart.service';
import { Order } from '../Models/order';

@Component({
  selector: 'app-orderdetails',
  templateUrl: './orderdetails.component.html',
  styleUrls: ['./orderdetails.component.css']
})
export class OrderdetailsComponent implements OnInit {
 
  constructor(private order:PharmaycartService,
    private item:OrderService,
    private toaster:ToastrService) 
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
    this.OrderUp.orderId=order.orderId;
    this.OrderUp.doctorId=order.doctorId;
    this.OrderUp.drugId=order.drugId;
    this.OrderUp.drugsName=order.drugsName;
    this.OrderUp.drugPrice=order.drugPrice;
    this.OrderUp.drugQuantity=order.drugQuantity;
    this.OrderUp.totalAmount=order.totalAmount;
    this.OrderUp.pickupDate=order.pickupDate;
    this.OrderUp.isPicked="Not Approved";
    this.item.UpdateOrder(this.OrderUp).subscribe((data)=>{
      console.log(this.OrderUp);
    this.toaster.success("Order Declined")

    });


  }
  confirmorder(order:Order){
    this.OrderUp.orderId=order.orderId;
    this.OrderUp.doctorId=order.doctorId;
    this.OrderUp.drugId=order.drugId;
    this.OrderUp.drugsName=order.drugsName;
    this.OrderUp.drugPrice=order.drugPrice;
    this.OrderUp.drugQuantity=order.drugQuantity;
    this.OrderUp.totalAmount=order.totalAmount;
    this.OrderUp.pickupDate=order.pickupDate;
    this.OrderUp.isPicked="Approved";
    this.item.UpdateOrder(this.OrderUp).subscribe((data)=>
    {
      console.log(this.OrderUp);
     
    }); 

    
      
   
    function delay(time: any) {
      return new Promise((resolve) => setTimeout(resolve, time));
    }

    delay(4000).then(() => console.log('ran after 1 second1 passed'));
   // window.location.reload();

  }
  
  updateQuantity(order:Order){
    this.item.GetDrug(order.drugId).subscribe((data)=>
    {
      this.drug=data;
      this.drug.drugQuantity=this.drug.drugQuantity-order.drugQuantity;
   
    if(this.drug.drugQuantity>this.OrderUp.drugQuantity){
    this.item.QuantityChange(this.drug).subscribe((data)=>
    {
      console.log(data);
     
      this.confirmorder(order);
      this.toaster.success("Order Confirmed")

    });
  }
  else{
    this.toaster.error("Unable to place the order");
  }
      
    });
  }
}
