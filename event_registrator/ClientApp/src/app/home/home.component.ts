import { Component, OnChanges } from '@angular/core';
import { UsersService } from '../services/users.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnChanges {

  isLogin:boolean;
  
  ngOnChanges(changes: import("@angular/core").SimpleChanges): void {
 //   console.log("homeonchanges");
  //  console.log(this.isLogin);
    var rcus = this.Userservice.getRoleCurrentConfirmedUser();
    if(rcus != "guest") this.isLogin = true;
  }

  constructor(private Userservice:UsersService, private router: Router){
 //   console.log("constructor home");
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
