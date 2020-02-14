import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { getBaseUrl } from 'src/main';

@Injectable({
  providedIn: 'root'
})
export class EventserviceService {

  events:any;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    var burl = getBaseUrl();
    var q = this.http.get(burl + 'api/events').subscribe((data) =>{
      this.events=data;
      console.log(this.events);
     });
  }

  getEvents():Array<myEvent>{
    return this.events;
  }
  addEvents(event:Event){
    var burl = getBaseUrl();
    this.http.post(burl + 'events', event).subscribe(res=>{console.log(res);});
  }
  initEvents(){
    var burl = getBaseUrl();
    var q = this.http.get(burl + 'api/events').subscribe((data) =>{
      this.events=data;
      console.log(this.events);
     });
  }
}
export interface myEvent{
  id:number;
  title:string;
  description:string;
  imagePath:string;
  dateStart:string;
  dateFinish:string;
  ownerId:number;
}
