import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { myEvent, EventserviceService } from '../services/eventservice.service';
import { UsersService } from '../services/users.service';
import { getBaseUrl } from 'src/main';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-createeventform',
  templateUrl: './createeventform.component.html',
  styleUrls: ['./createeventform.component.css']
})
export class CreateeventformComponent implements OnInit {

  selectedfile:File = null;
  createEventForm:FormGroup;
  us:UsersService;
  uploudEventPath:string = "";

  constructor(
    private UserService:UsersService,
    private EventService:EventserviceService, 
    private http:HttpClient,
    private router: Router) { 
      this.us = UserService;
    }

  ngOnInit() {
    this.createEventForm = new FormGroup({
      title: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      imagePath: new FormControl('', Validators.required),
      dateStart: new FormControl('', Validators.required),
      dateFinish: new FormControl('', Validators.required)
    });
  }

  createEvent(e:{
    id:number,
    title:string, 
    description:string, 
    imagePath:string,
    dateStart:string,
    dateFinish:string,
    ownerId:number }):myEvent{
    return e;
  }

  onFileSelected(event){
   //    console.log(event);
       this.selectedfile = <File>event.target.files[0];
   //    console.log(this.selectedfile);
     }

  onSubmit(){
  //  console.log(this.selectedfile.name);
  //  console.log(this.createEventForm);
    var uId = this.us.currentConfirmedUserObject.id;
    var e = this.createEvent({
    id:0,
    title:this.createEventForm.controls.title.value, 
    description:this.createEventForm.controls.description.value, 
    imagePath:this.selectedfile.name,
    dateStart:this.createEventForm.controls.dateStart.value,
    dateFinish:this.createEventForm.controls.dateFinish.value,
    ownerId:uId
    })
   // console.log(e); 
   
   const fd = new FormData;
   fd.append('files', this.selectedfile, this.selectedfile.name)
   console.log(fd);
   var burl = getBaseUrl();
   this.http.post(burl + 'uf', fd).subscribe(res=>{
     let r:any = res;
     this.uploudEventPath = r.filePaths[0];
     console.log(this.uploudEventPath);
     console.log(res);
    });
   console.log("submit end");
   setTimeout(()=>{
     this.sendInformationToDatabase()
   }, 1000)
setTimeout(()=>{
  this.router.navigate(['']);
},2000);
  }

  sendInformationToDatabase(){
    var burl = getBaseUrl();
    var uId = this.us.currentConfirmedUserObject.id;
    var e = this.createEvent({
      id:0,
      title:this.createEventForm.controls.title.value, 
      description:this.createEventForm.controls.description.value, 
      imagePath:this.uploudEventPath,
      dateStart:this.createEventForm.controls.dateFinish.value,
      dateFinish:this.createEventForm.controls.dateFinish.value,
      ownerId:uId
      })
   this.http.post(burl + 'api/events', e).subscribe(res=>{
     console.log(res);
    });
  }

}
