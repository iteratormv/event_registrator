import { Component, OnChanges } from '@angular/core';
import { UsersService } from '../services/users.service';
import { Router } from '@angular/router';
import { myEvent, EventserviceService } from '../services/eventservice.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnChanges {

  isLogin:boolean;
  events:Array<myEvent>;
  es:EventserviceService;
  
  ngOnChanges(changes: import("@angular/core").SimpleChanges): void {
 //   console.log("homeonchanges");
  //  console.log(this.isLogin);
    var rcus = this.Userservice.getRoleCurrentConfirmedUser();
    if(rcus != "guest") this.isLogin = true;
  }

  constructor(
    private Userservice:UsersService, 
    private router: Router, 
    private Eventservice:EventserviceService){
    console.log("constructor home");
    this.es = Eventservice;
    this.es.initEvents();
    setTimeout(()=>{
      this.events = Eventservice.getEvents();
      
      console.log(this.events)
    }, 1500);
    setTimeout(()=>{
      var rcus = this.Userservice.getRoleCurrentConfirmedUser();
      if(rcus != "guest") this.isLogin = true;
      console.log(rcus);
    }, 1000);
  }

  onEventCreate(){
//    alert("inent create");
    this.router.navigate(['createeventform']);
  }

  onClickElement(element:number){
//    alert('element click ' + element);
  this.es.initSelectedEvent(element);
  setTimeout(()=>{
    this.router.navigate(['eventdetail']);
  });
  }


}
