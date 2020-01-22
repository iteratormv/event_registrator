import { Component, OnInit, OnChanges } from '@angular/core';
import { UsersService } from '../services/users.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-loginform',
  templateUrl: './loginform.component.html',
  styleUrls: ['./loginform.component.css']
})
export class LoginformComponent implements OnInit, OnChanges {

  loginForm:FormGroup;

  ngOnChanges(changes: import("@angular/core").SimpleChanges): void {
    throw new Error("Method not implemented.");
  }

  constructor(private UserService:UsersService, private router: Router) { }
  ngOnInit() {
    this.loginForm = new FormGroup({
      userEmail: new FormControl('', 
      [
        Validators.required,
        Validators.email
      ]),
      userPassword: new FormControl('', Validators.required)
    });
  }
  checkUser():boolean{
    let result:boolean = false;
    var users = this.UserService.getUsers();
    users.forEach(user=>{
      console.log(user)
      if(user.email == this.loginForm.controls['userEmail'].value){
        if(user.password == this.loginForm.controls['userPassword'].value){
          this.UserService.currentUser = user.firstName;
          this.UserService.currentConfirmedUser = user.firstName + " " + user.surName;
//          this.UserService.roleCurrentConfermedUser = user.
          result = true;
        }
      } 
    });
    return result;
  }
  onSubmit(){
    var compare = this.checkUser();
    if(compare){
      this.router.navigate(['']);
    }else alert("логин или пароль неверый")
  }

}
