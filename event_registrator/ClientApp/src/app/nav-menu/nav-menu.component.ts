import { Component, Input, OnChanges } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnChanges  {

  ngOnChanges(changes: import("@angular/core").SimpleChanges): void {
   // console.log("onChanges");
   // console.log("nav onchange userName = " + this.userName); 
   // console.log("nav onchange before islogin - " + this.isLogin);
    if(this.userRole!="guest") this.isLogin = true;
    else this.isLogin = false;
    if(this.userRole!="superUser") this.canAdministrate = false;
    else this.canAdministrate = true;
    
   // console.log("nav onchange after islogin - " + this.isLogin);
  }
  isExpanded = false;
  isLogin = false;
  canAdministrate = false;
  @Input() userName: string;
  @Input() userRole: string;

  constructor(){
    // if(this.userName!="guest") this.isLogin == true;
// console.log("nav userName = " + this.userName); 
// console.log("nav islogin - " + this.isLogin);
  }

  collapse() {
    this.isExpanded = false;
//    console.log("collapse userName = " + this.userName); 
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
 //   console.log("toggle userName = " + this.userName); 
  }
}
