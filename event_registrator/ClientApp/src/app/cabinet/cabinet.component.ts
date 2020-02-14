import { Component, OnInit, OnChanges, Inject } from '@angular/core';
import { UsersService } from '../services/users.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { getBaseUrl } from 'src/main';
import { HubConnection, HubConnectionBuilder } from "@aspnet/signalr"
//import { setTimeout } from 'timers';

@Component({
  selector: 'app-cabinet',
  templateUrl: './cabinet.component.html',
  styleUrls: ['./cabinet.component.css']
})
export class CabinetComponent implements OnInit, OnChanges {

  canAdministrate:boolean;
  canSendFile:boolean;
  selectedfile:File = null;

  private _hubConnection: HubConnection;
  private connectionIsEstablished = false; 
  public message:string='';
  public messages:string[]=[]; 
 // tempfile:File = null;

  ngOnChanges(changes: import("@angular/core").SimpleChanges): void {
 //   console.log("cabinet onchanges");
    var rcus = this.Userservice.getRoleCurrentConfirmedUser();
    if(rcus != "superUser") this.canAdministrate = false;
    else this.canAdministrate = true;
   }

  constructor(
    private Userservice:UsersService, 
    private router: Router, 
    private http:HttpClient, 
    @Inject('BASE_URL') baseUrl: string) { 
 //   console.log("constructor cabinet");
    var rcus = this.Userservice.getRoleCurrentConfirmedUser();
    if(rcus != "superUser") this.canAdministrate = false;
    else this.canAdministrate = true;
    this.canSendFile = false;
 //   console.log(rcus);
  }

  ngOnInit() {
    this.createConnection();  
    this.registerOnServerEvents();  
    this.startConnection();

    this._hubConnection.on("Send", (msg)=>{
      if(msg=="clear message") {this.messages = []}
      else this.messages.push(msg);
    })
  }

  createWebSocketConnection(){
 //   console.log("createwebsocketConnection");


  }

  private createConnection() {  
 //   console.log("createconnection")
//    console.log(window.location.href + '/echo');
 //   console.log('http://localhost:5000/echo')
    this._hubConnection = new HubConnectionBuilder()  
      .withUrl(window.location.href + '/echo') 
  //    .withUrl('http://localhost:5000/echo') 
      .build();  
  //    console.log(this._hubConnection);
  }  
  private startConnection(): void { 
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
  private registerOnServerEvents(): void {  
 //   console.log("registrateOnserverEvents")
    this._hubConnection.on('MessageReceived', (data: any) => {  
   //   this.messageReceived.emit(data);  
 //  console.log(data);
    });  
  }
  
  AcauntExit(){
    this.Userservice.setGuest();
    this.router.navigate(['']);
  }

  SendFile(){
    this.canSendFile = true;
  }

  onFileSelected(event){
    console.log(event);
    this.selectedfile = <File>event.target.files[0];
    console.log(this.selectedfile);
  }

  onUpload(){
//    console.log("do post")
//    console.log(this.selectedfile);
   const fd = new FormData;
    fd.append('files', this.selectedfile, this.selectedfile.name)
    console.log(fd);
    var burl = getBaseUrl();
    this.http.post(burl + 'uf', fd).subscribe(res=>{console.log(res);});
    this.message = this.selectedfile.name;


    setTimeout(()=>{
      this.echo();
    }, 6000);


 //   this.createWebSocketConnection();
 //   this.http.post('http://localhost:50892/api/uploadfile', fd).subscribe(res=>{console.log(res);});
  }

  echo(){   
    this._hubConnection.invoke("Echo", this.message);
  }

}
