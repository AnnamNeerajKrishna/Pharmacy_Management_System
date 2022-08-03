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
 
  constructor(private order:PharmaycartService,private item:OrderService) { 
    
  }
Orders:Order[]=[];
  ngOnInit(): void {
    this.GetOrderDetails();
  }
  GetOrderDetails() {
    this.item.GetOrders().subscribe((data) => {
      this.Orders = data;
    });
  }
  

}
