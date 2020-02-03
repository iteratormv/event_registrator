import { Component, OnChanges } from '@angular/core';
import { UsersService } from '../services/users.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnChanges {

  isLogin:boolean;
  
  ngOnChanges(changes: import("@angular/core").SimpleChanges): void {
  //  console.log("homeonchanges");
    var rcus = this.Userservice.getRoleCurrentConfirmedUser();
    if(rcus != "guest") this.isLogin = true;
  }

  constructor(private Userservice:UsersService){
 //   console.log("constructor home");
    var rcus = this.Userservice.getRoleCurrentConfirmedUser();
    if(rcus != "guest") this.isLogin = true;
 //   console.log(rcus);
  }


}
