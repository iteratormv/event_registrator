import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UsersService implements OnInit {

  public users:any;

  ngOnInit() {
    this.http.get('http://localhost:50892/api/users').subscribe((data) => this.users=data);
  }

  constructor(private http: HttpClient) { }

  public getUsers():Array<any>{
    return this.users;
  }

}
