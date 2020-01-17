import { Component } from '@angular/core';
import { UsersService } from './services/users.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  providers:[UsersService]
})
export class AppComponent {
  title = 'app';
  userName:string;
  userRole:string;
  us:UsersService;
  constructor(){
    this.userName = "guest";
    this.userRole = "guest";
//    var e = this.us.ngOnChanges;
 //   console.log(e.name);
  }
  initUser(){
    this.userName = this.us.currentConfirmedUser;
  }
}
