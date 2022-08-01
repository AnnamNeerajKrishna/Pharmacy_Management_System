import { PharmacyServiceService } from './../Shared/pharmacy-service.service';
import { Drugs } from './../Models/drugs';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-userdashboard',
  templateUrl: './userdashboard.component.html',
  styleUrls: ['./userdashboard.component.css']
})
export class UserdashboardComponent implements OnInit {
  public DrugList: Drugs[] = [];
  constructor(private drug : PharmacyServiceService) { }

  ngOnInit(): void {
    this.GetAllDrugs();
  }
  GetAllDrugs() {
    this.drug.getalldrugs().subscribe((data) => {
      //console.log(data);
      this.DrugList = data;
      console.log(this.DrugList.length);
    });
  }
  LogOut() {
    localStorage.removeItem('token');
  }
}
