import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl, ValidatorFn } from '@angular/forms';
import { UsersService } from '../services/users.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { VisitorService } from '../services/visitor.service';

@Component({
  selector: 'app-visitorform',
  templateUrl: './visitorform.component.html',
  styleUrls: ['./visitorform.component.css']
})
export class VisitorformComponent implements OnInit {

  visitorForm:FormGroup;
  us:UsersService;
  vs:VisitorService;
  isSubmitted:boolean;

  private _hubConnection: HubConnection;
  private connectionIsEstablished = false; 
  public message:string='';

  constructor(
    private UserService:UsersService, 
    private VisitorService:VisitorService,
    private router: Router,
    private http: HttpClient) {
      this.us = UserService;
      this.vs = VisitorService;
      this.isSubmitted = false; 
     }

  ngOnInit() {
 //   this.createConnection();  
 //   this.registerOnServerEvents();  
 //   this.startConnection();

    // this._hubConnection.on("Send", (msg)=>{
    //   // if(msg=="clear message") {this.messages = []}
    //   // else this.messages.push(msg);
    // })

    this.visitorForm =  new FormGroup({
      userFirstName:new  FormControl('',Validators.required),
      userSurName:new  FormControl('',Validators.required),
      userEmail: new FormControl('', 
      [
        Validators.required,
        this.emailAddedValidator(),
        Validators.email
      ]),
      userPassword: new FormControl('', Validators.required),
      confirmUserPassword: new FormControl('', [
 //     Validators.required
      ,
      this.confirmPasswordValidator()
      ])
    })
  }

  startConnection() {
 //   console.log("start start connection") 
 this._hubConnection  
 .start()   
 .then(() => {  
   this.connectionIsEstablished = true;  
//     console.log('Hub connection started');  
   // this.connectionEstablished.emit(true);  
 })  
 .catch(err => {  
//      console.log('Error while establishing connection, retrying...');  
   setTimeout(function () { this.startConnection(); }, 5000);  
 }); 
  }
  createConnection() {
 //   console.log("createconnection")
//    console.log(window.location.href + '/echo');
 //   console.log('http://localhost:5000/echo')
 this._hubConnection = new HubConnectionBuilder()  
 .withUrl(window.location.href + '/sendMailToVisitor') 
//    .withUrl('http://localhost:5000/echo') 
 .build();  
//    console.log(this._hubConnection);
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
  checkEmail():boolean{
    let dut:boolean;
    if(this.visitorForm == null) return false;
    let controlValue = this.visitorForm.controls['userEmail'].value;
   if(controlValue==null) return false;
    dut = false;
    let us = this.us.getUsers();
    if(us == null) return false;
    us.forEach(element => {
//      console.log(element.userEmail + " checkEmail " + controlValue)
      if(element.email == controlValue) {
        dut = true;
 //       console.log("checkEmail let " + dut)
      }
    });

 //console.log("checkEmail return " + dut)
    return dut;
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
  checkConfirmPassword1():boolean{
    if(this.visitorForm == null) return false;
    let pass = this.visitorForm.controls['userPassword'].value;
    let cpass = this.visitorForm.controls['confirmUserPassword'].value;
    if(pass!=cpass) return true;
    else return false;
  }
  onSubmit(){

    //    console.log(this.isSubmitted);
        if(this.visitorForm.value.userPassword != this.visitorForm.value.confirmUserPassword)
        {
          alert("пароли не совпадают");
          this.isSubmitted=false;
          return;
        }
        if(this.isSubmitted === true) {
          console.log("request did not sent becouse previos reques is not finished");
           return;
           }
        else{
          this.isSubmitted = true;
          if(this.isSubmitted==true){
      //      alert("отсылаю письмо");
            console.log("send mail" + this.visitorForm.value.userEmail+ '|' + this.visitorForm.value.userPassword)
            let u:any = {"email": this.visitorForm.value.userEmail,
                         "password":this.visitorForm.value.userPassword,
                         "firstName":this.visitorForm.value.userFirstName,
                         "surName":this.visitorForm.value.userSurName};
      //      console.log("on submit userEmail = " + this.registrationForm.value.userEmail);
            // u.email = this.registrationForm.value.userEmail.toString();
            let v:any = {"email": this.visitorForm.value.userEmail,
                         "password":this.visitorForm.value.userPassword,
                         "firstName":this.visitorForm.value.userFirstName,
                         "surName":this.visitorForm.value.userSurName,
                         "barCode":"11111",
                         "Category":"Guest",
                         "currentStatus":"registrate",
                         "paymentStatus":"FREE",
                         "eventId":1};
     //        console.log(u);
            // u.firstName = this.registrationForm.value.userFirstName;
            // u.surName = this.registrationForm.value.userSurName;
            // u.password = this.registrationForm.value.password;
            // console.log(this.registrationForm.value.userEmail);
      //      console.log(u);
    
    //        this.us.sendmail(this.registrationForm.value.userEmail+'|'+this.registrationForm.value.userPassword);
            this.us.addUser(u);
            this.vs.addVisitor(v);
        //    this.sendMailToVisitor();
            this.us.currentUser = this.visitorForm.value.userEmail;
            this.router.navigate(['']);
          }
        }
      }

  sendMailToVisitor(){   
     this._hubConnection.invoke("SendMailToVisitor", this.message);
  }

}
