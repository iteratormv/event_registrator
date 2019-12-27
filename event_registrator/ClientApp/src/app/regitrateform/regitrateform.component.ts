import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UsersService } from '../services/users.service';

@Component({
  selector: 'app-regitrateform',
  templateUrl: './regitrateform.component.html',
  styleUrls: ['./regitrateform.component.css']
})
export class RegitrateformComponent implements OnInit {

  registrationForm:FormGroup;
  isSubmitted:boolean;
  public users:Array<any>;
 // private UserService:UsersService;


  constructor(private UserService:UsersService)
   { 
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
      return;
    }
    if(this.isSubmitted === true) {console.log("request did not sent becouse previos reques is not finished"); return; }
    else{
      this.isSubmitted = true;
      //send request and after request set isSubmitted=false

//      console.log(this.registrationForm.value);
//      setTimeout(() => {console.log("set timeout"+ this.isSubmitted); this.isSubmitted = false;}, 5000);



    }
  }

}





