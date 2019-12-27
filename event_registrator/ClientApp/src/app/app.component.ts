import { Component } from '@angular/core';
import { UsersService } from './services/users.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  providers:[UsersService]
})
export class AppComponent {
  title = 'app';
}
