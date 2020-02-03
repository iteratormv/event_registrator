import { Component, OnChanges, OnInit, DoCheck } from '@angular/core';
import { UsersService } from './services/users.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  providers:[UsersService]
})
export class AppComponent implements OnChanges, OnInit, DoCheck {
  ngDoCheck(): void {
 //   console.log("docheck");
    this.userName = this.us.getCurrentConfermedUser();   
  //  console.log(this.userName);
    this.userRole = this.us.getRoleCurrentConfirmedUser();
   // console.log(this.userRole);
  }
  ngOnInit(): void {

 //   console.log("app oninit");
 //   console.log(this.UserService.getCurrentConfermedUser());
//    setInterval(this.MonitorUser, 1000);
  }
  ngOnChanges(changes: import("@angular/core").SimpleChanges): void {
  //  console.log("app oninit onchanges");
  //  console.log(this.userName);
  //  console.log(this.userRole);
//    console.log(this.UserService.getCurrentConfermedUser());
//    setInterval(this.MonitorUser, 1000);

  }
  title = 'app';
  userName:string;
  userRole:string;
  public us:UsersService;
  constructor(private UserService:UsersService){
 //   console.log("app constructor");
    this.userName = "guest";
    this.userRole = "guest";
    this.us = UserService;
 //   console.log(this.UserService.getCurrentConfermedUser());
  //  console.log(this.us.getCurrentConfermedUser());
//    var e = this.us.ngOnChanges;
 //   console.log(e.name);
//setTimeout(setInterval(this.MonitorUser,1000),1000)
// setTimeout(this.initUser,1000);


  }
  initUser(u:UsersService){
    this.userName = u.getCurrentConfermedUser();
 //   this.userRole = 
 //   console.log(this.userName);
  }


  
  MonitorUser(){   
    this.initUser(this.us);
  }
}
