import { Drugs } from './../Models/drugs';
import { Component, OnInit } from '@angular/core';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
import { Order } from '../Models/order';
import { OrderService } from '../Shared/order.service';
@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.css'],
})
export class SalesComponent implements OnInit {
  DrugDetail: Order[] = [];
  TotalSalesAmount: any = 0;
  searchText: any;
  total=0
  constructor(private orderservice:OrderService) {}

  ngOnInit(): void {
    this.ShowSalesData();
  }
  LogOut() {
    localStorage.removeItem('role');
  }

  ShowSalesData() {
    this.orderservice.GetOrders().subscribe((data) => {
      for (let x of data) {
        if (x.isPicked == 'Approved') {
          this.DrugDetail.push(x);
          this.TotalSalesAmount += x.totalAmount;
        }
      }
    });
  }
  TotalAmount(Drugs:any){
    for (let x of Drugs) {

      this.total = this.total + x.drugQuantity * x.drugPrice;

    }

  }

  PDFbtn() {
    console.log('Downloading PDF');
    let data = document.getElementById('PDFbtnDiv');
    this.generatePDF(data);
  }
   generatePDF(htmlContent) {
    html2canvas(htmlContent).then((canvas) => {
      let imgWidth = 120;
      let imgHeight = (canvas.height * (1.2 * imgWidth)) / canvas.width;
      const contentDataURL = canvas.toDataURL('image/png');
      let pdf = new jsPDF('p', 'mm', 'a5');
      var position = 5;
      //pdf.text('Instruction', 60, 10);
      pdf.addImage(contentDataURL, 'PNG', 15, position, imgWidth, imgHeight);
      pdf.setLineWidth(0.5);
      pdf.rect(5, 3, 140, 204);
      pdf.save('SalesReport.pdf');
    }); 
  }
}