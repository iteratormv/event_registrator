import { Component, OnInit, Inject, Input } from '@angular/core';
import { UsersService } from 'src/app/services/users.service';
import { Router } from '@angular/router';
import { useAnimation } from '@angular/animations';
import { delay } from 'rxjs/operators';

@Component({
  selector: 'app-endregistrate',
  templateUrl: './endregistrate.component.html',
  styleUrls: ['./endregistrate.component.css']
})




export class EndregistrateComponent implements OnInit {

  
  canredirect:boolean;
  us:UsersService;
  @Input() userName: string;

  constructor(private UserService:UsersService, private router: Router, @Inject('BASE_URL') baseUrl: string ){
    console.log("endreg  -");
 //   console.log(this.userName);
     this.canredirect = false; 
     this.us = UserService;
     setInterval(()=>{
      this.MonitoringCanRedirect();
     }, 3000)
    }
  ngOnInit() {
  }
  RedirectToHome(){
    this.router.navigate(['']);
  }
  async MonitoringCanRedirect(){
        var qq = await this.us.initUsers();
       setTimeout(()=>{
        var uss = this.gu();
        var BreakException = {};
        try{
            uss.forEach(item=>{
              if(item.userEmail == this.us.currentUser){
                this.us.currentConfirmedUser = this.us.currentUser;
                console.log("endregistrate " + this.us.currentConfirmedUser)
                this.canredirect = true;
                throw BreakException;
              }
            })
        }catch (e) {
          if (e !== BreakException) throw e;
         }
       },1000)    
  }
  gu():any[]{
    var q = this.us.getUsers();
    return q;
  }
  delay(ms:number):any[]{
    let u:any[];
    setTimeout(async ()=>{
      var uss = this.gu();
      u = await uss;
     },5000)
    return u;
  }

}
