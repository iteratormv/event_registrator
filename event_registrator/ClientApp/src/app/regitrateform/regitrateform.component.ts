import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UsersService } from '../services/users.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';

@Component({
  selector: 'app-regitrateform',
  templateUrl: './regitrateform.component.html',
  styleUrls: ['./regitrateform.component.css']
})
export class RegitrateformComponent implements OnInit {

  registrationForm:FormGroup;
  isSubmitted:boolean;
  public users:Array<any>;
  public us:UsersService;
 // private UserService:UsersService;


  constructor(private UserService:UsersService, private router: Router,private http: HttpClient)
   { 
     this.us = UserService;
     this.users = UserService.getUsers();
     this.isSubmitted = false; 
    }

  ngOnInit() {
    this.registrationForm = new FormGroup({
      userEmail : new FormControl('',[Validators.required, Validators.email]),
      userPassword : new FormControl('', Validators.required),
      confirmUserPassword : new FormControl('', Validators.required)
    })
  }

  onSubmit(){
    console.log(this.isSubmitted);
    if(this.registrationForm.value.userPassword != this.registrationForm.value.confirmUserPassword)
    {
      alert("пароли не совпадают");
      this.isSubmitted=false;
      return;
    }
    if(this.isSubmitted === true) {console.log("request did not sent becouse previos reques is not finished"); return; }
    else{
      this.isSubmitted = true;

      if(this.isSubmitted==true){
        alert("отсылаю письмо");
  //      this.http.get('https://www.google.com.ua/');
//     window.location.href = 'http://localhost:50892/api/sendmail/' + this.registrationForm.value.userEmail;
        this.us.sendmail(this.registrationForm.value.userEmail+'|'+this.registrationForm.value.userPassword);
 //      this.router.navigate(['counter']);
      }
      //send request and after request set isSubmitted=false

//      console.log(this.registrationForm.value);
//      setTimeout(() => {console.log("set timeout"+ this.isSubmitted); this.isSubmitted = false;}, 5000);



    }
  }

}





