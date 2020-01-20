import { Component, OnChanges } from '@angular/core';
import { UsersService } from '../services/users.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnChanges {

  isLogin:boolean;
  
  ngOnChanges(changes: import("@angular/core").SimpleChanges): void {
    console.log("homeonchanges");
    var cus = this.Userservice.getCurrentConfermedUser();
    if(cus != "guest") this.isLogin = true;
  }

  constructor(private Userservice:UsersService){
    console.log("constructor home");
    var cus = this.Userservice.getCurrentConfermedUser();
    if(cus != "guest") this.isLogin = true;
    console.log(cus);
  }


}
