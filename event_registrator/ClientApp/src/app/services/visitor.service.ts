import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Visitor } from '@angular/compiler/src/i18n/i18n_ast';
import { getBaseUrl } from 'src/main';

@Injectable({
  providedIn: 'root'
})
export class VisitorService {

  visitors:any;

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') baseUrl: string) {

     }

  getVisitors():Array<eVisitor>{
    return this.visitors;
  }

  initvisitor(){
    var burl = getBaseUrl();
    this.http.get(burl + 'api/visitors').subscribe((data)=>{
      this.visitors = data;
    });
  }

  addVisitor(visitor:eVisitor){
    var burl = getBaseUrl();
    this.http.post(burl + 'api/visitors', visitor).subscribe((data)=>{
      console.log(data);
    })
  }
}


export interface eVisitor{
  id:number;
  firstName:string;
  surName:string;
  email:string;
  company:string;
  jobTitle:string;
  category:string;
  barCode:string;
  currentStatus:string;
  paymentStatus:string;

  addedInformation1:string;
  addedInformation2:string;
  addedInformation3:string;
  addedInformation4:string;
  addedInformation5:string;
  addedInformation6:string;
  addedInformation7:string;
  addedInformation8:string;
  addedInformation9:string;
  addedInformation10:string;

  eventId:number;
  statuses:string[];
}