import { Drugs } from './../Models/drugs';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PharmaycartService {
  drugId: any;

  constructor() { }
  Druglist:Drugs[]=[];
  sendDrugData(drug:Drugs){
    this.Druglist.push(drug);
  }
  GetCartData(){
    return this.Druglist;
  }

}
