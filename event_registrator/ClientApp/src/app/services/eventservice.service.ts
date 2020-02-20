import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { getBaseUrl } from 'src/main';

@Injectable({
  providedIn: 'root'
})
export class EventserviceService {

  events:any;
  selectedEvent:myEvent = null;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    // var burl = getBaseUrl();
    // var q = this.http.get(burl + 'api/events').subscribe((data) =>{
    //   this.events=data;
    //   console.log(this.events);
    //  });
    this.initEvents();
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
      // this.events.forEach(element => {
      //   var temp = element.dateStart.;
      //   element.dateStart = 
      // });
      console.log(this.events);
     });
  }

  initSelectedEvent(eventId:number){
    var ev = this.getEvents();
    ev.forEach(element => {
      if(element.id == eventId) this.selectedEvent =  element;
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
