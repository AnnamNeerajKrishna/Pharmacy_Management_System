import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Drugs } from '../Models/drugs';
import { Observable } from 'rxjs';
import { Suppliers } from '../Models/suppliers';
@Injectable({
  providedIn: 'root'
})
export class PharmacyServiceService {
  baseUrl='https://localhost:44348';
  constructor(private http:HttpClient) { }



  getalldrugs():Observable<Drugs[]>{
    return this.http.get<Drugs[]>(this.baseUrl+'/api/Drugs');
  }
  AddDrugs(drug:Drugs):Observable<Drugs>{
    return this.http.post<Drugs>(this.baseUrl+'/api/Drugs',drug);
  }
  deleteDrugs(drug:number):Observable<Drugs>{
    return this.http.delete<Drugs>(this.baseUrl+'/api/Drugs/'+drug);
  }
  updateDrug(drug:Drugs):Observable<Drugs>{
    return this.http.put<Drugs>(this.baseUrl+'/api/Drugs/'+drug.drugId,drug);

  }
   getAllSupplierdata():Observable<Suppliers[]>{
    return this.http.get<Suppliers[]>(this.baseUrl+'/api/Suppliers/GetAllSuppliers');
  }

  AddSupplier(supplier:Suppliers):Observable<Suppliers>{
    return this.http.post<Suppliers>(this.baseUrl+'/api/Suppliers',supplier);
  }
  deleteSupplier(id:number):Observable<Suppliers>{
    return this.http.delete<Suppliers>(this.baseUrl+'/api/Suppliers/'+id);
  } 
  updateSupplier(supplier:Suppliers):Observable<Suppliers>{
    return this.http.put<Suppliers>(this.baseUrl+'/api/Suppliers/'+supplier.supplierId,supplier);
  }
}
