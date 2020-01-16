import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, ValidatorFn, AbstractControl } from '@angular/forms';
import { UsersService, booleanReturn } from '../services/users.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { async } from '@angular/core/testing';
import { promise } from 'protractor';

@Component({
  selector: 'app-regitrateform',
  templateUrl: './regitrateform.component.html',
  styleUrls: ['./regitrateform.component.css']
})

export class RegitrateformComponent implements OnInit {
  [x: string]: any;

  registrationForm:FormGroup;
  isSubmitted:boolean;
  public users:Array<any>;
  public us:UsersService;
  public da:any;

  //Object whith errors which will print in UI
  formErrors = {
    'userEmail':'',
    'userPassword':'',
    'confirmUserPassword':''
  }

  //Object with user messages
  validationMessages = {
    userEmail:{
      "required":"Обязательное поле",
      "emailAddedValidator":"Пользователь с таким email уже зарегистрирован"
    },
    userPassword:{
      "required":"Обязательно поле"
    },
    confirmUserPassword:{
      "required":"Обязательно поле",
      "confirmPasswordValidator":"Пароли не совпадают"
    }

  }

  constructor(private UserService:UsersService, private router: Router,private http: HttpClient){ 
     this.us = UserService;
//     console.log("constroctor form - " + this.users);
     this.isSubmitted = false; 
    }
  ngOnInit() {
    this.registrationForm = new FormGroup({
        userEmail: new FormControl('', 
        [
          Validators.required,
          this.emailAddedValidator(),
          Validators.email
        ]),
        userPassword: new FormControl('', Validators.required),
        confirmUserPassword: new FormControl('', [
        Validators.required,
        this.confirmPasswordValidator()
        ])
      });
  }

  onValueChange(data?:any){
    if(!this.registrationForm) return;
    let form = this.registrationForm;
    for(let field in this.formErrors){
      this.registrationForm[field] = "";
    }
  }
  checkEmail1(){
    let controlValue = this.registrationForm.controls['userEmail'].value;
//    console.log(this.getUsers());
    let dut:boolean;
    let us = this.us.getUsers();
    us.forEach(element => {
      if(element.userEmail == controlValue) dut = true;
      else dut = false;
    });
    if(dut==true) this.registrationForm.controls['userEmail']
    .setValue(controlValue + " уже используется");
    else {};
  }
  checkEmail():boolean{
    let dut:boolean;
    if(this.registrationForm == null) return false;
    let controlValue = this.registrationForm.controls['userEmail'].value;
   if(controlValue==null) return false;
    dut = false;
    let us = this.us.getUsers();
    if(us == null) return false;
    us.forEach(element => {
//      console.log(element.userEmail + " checkEmail " + controlValue)
      if(element.userEmail == controlValue) {
        dut = true;
 //       console.log("checkEmail let " + dut)
      }
    });

 //console.log("checkEmail return " + dut)
    return dut;
  }
  async isContainUserInDatabase(v:any):Promise<boolean>{
    var d = await this.us.isContainUser(v);
    return d;
  }
  checkConfirmPassword(){
    let message;
    let pass = this.registrationForm.controls['userPassword'].value;
    let cpass = this.registrationForm.controls['confirmUserPassword'].value;
    if(pass!=cpass){
      message = "Пароли не совпадают";
      this.registrationForm.controls['confirmUserPassword'].setValue("");
    }
  }
  checkConfirmPassword1():boolean{
    if(this.registrationForm == null) return false;
    let pass = this.registrationForm.controls['userPassword'].value;
    let cpass = this.registrationForm.controls['confirmUserPassword'].value;
    if(pass!=cpass) return true;
    else return false;
  }
  emailAddedValidator(): ValidatorFn {
    return (control: AbstractControl): {[key: string]: any} | null => {
      var de:boolean = this.checkEmail();
      if(de == true)
      {
//        console.log("emailvalidator return cv");
        return {"emailAddedValidator": control.value};
      }
      else 
      {
 //       console.log("emailvalidator return null");
        return  null;
      }
    };
  }
  confirmPasswordValidator(): ValidatorFn {
    return (control: AbstractControl): {[key: string]: any} | null => {
      var de:boolean = this.checkConfirmPassword1();
      if(de == true)
      {
 //       console.log("emailvalidator return cv");
        return {"confirmPasswordValidator": control.value};
      }
      else 
      {
 //       console.log("emailvalidator return null");
        return  null;
      }
    };
  }
  onSubmit(){
//    console.log(this.isSubmitted);
    if(this.registrationForm.value.userPassword != this.registrationForm.value.confirmUserPassword)
    {
//      alert("пароли не совпадают");
      this.isSubmitted=false;
      return;
    }
    if(this.isSubmitted === true) {
//      console.log("request did not sent becouse previos reques is not finished");
       return;
       }
    else{
      this.isSubmitted = true;
      if(this.isSubmitted==true){
  //      alert("отсылаю письмо");
//        console.log("send mail" + this.registrationForm.value.userEmail+'|'+this.registrationForm.value.userPassword)
        this.us.sendmail(this.registrationForm.value.userEmail+'|'+this.registrationForm.value.userPassword);
        this.us.currentUser = this.registrationForm.value.userEmail;
        this.router.navigate(['endregistrate']);
      }
    }
  }
}




