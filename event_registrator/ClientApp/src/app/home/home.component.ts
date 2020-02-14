import { Component, OnChanges } from '@angular/core';
import { UsersService } from '../services/users.service';
import { Router } from '@angular/router';
import { myEvent, EventserviceService } from '../services/eventservice.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnChanges {

  isLogin:boolean;
  events:Array<myEvent>;
  
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
    Eventservice.initEvents();
    setTimeout(()=>{
      this.events = Eventservice.getEvents();
      console.log(this.events)
    }, 100);
    setTimeout(()=>{
      var rcus = this.Userservice.getRoleCurrentConfirmedUser();
      if(rcus != "guest") this.isLogin = true;
 //     console.log(rcus);
    }, 100);
  }

  onEventCreate(){
//    alert("inent create");
    this.router.navigate(['createeventform']);
  }


}
