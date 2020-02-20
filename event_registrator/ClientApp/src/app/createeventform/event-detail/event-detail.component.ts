import { Component, OnInit } from '@angular/core';
import { myEvent, EventserviceService } from 'src/app/services/eventservice.service';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.css']
})
export class EventDetailComponent implements OnInit {

  event:myEvent

  constructor(private eventService:EventserviceService) {
    this.event = eventService.selectedEvent;
   }

  ngOnInit() {
  }

}
