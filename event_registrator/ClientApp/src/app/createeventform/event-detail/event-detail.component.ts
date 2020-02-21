import { Component, OnInit } from '@angular/core';
import { myEvent, EventserviceService } from 'src/app/services/eventservice.service';
import { UsersService, User } from 'src/app/services/users.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.css']
})
export class EventDetailComponent implements OnInit {

  event:myEvent;
  user:User;
  isLogin:boolean;

  constructor(
    private eventService:EventserviceService,
    private userService:UsersService,
    private router: Router) {
    this.event = eventService.selectedEvent;
    this.user = userService.currentConfirmedUserObject;
    if(this.user.id!=2) this.isLogin = true;
    else this.isLogin = false;
    console.log(this.user);
    console.log(this.event);
    }


  ngOnInit() {
  }

  onRegistrateClick(){
    this.router.navigate(['vizitorform']);
  }

}
