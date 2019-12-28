import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { getBaseUrl } from 'src/main';

@Injectable({
  providedIn: 'root'
})
export class UsersService implements OnInit {

  public users:any;
  public burl:any;

  ngOnInit() {
 //   this.http.get('http://localhost:50892/api/users').subscribe((data) => this.users=data);
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { }

  public getUsers():Array<any>{
    var burl = getBaseUrl();
    this.http.get(burl + 'api/users').subscribe((data) => this.users=data);
    return this.users;
  }

  public sendmail(datau:string) : string{
    let r:string;
    var burl = getBaseUrl();
    this.http.get(burl + 'api/sendmail/' + datau).subscribe(result => {
      r = result.toString();
    }, error => console.error(error));
 //   this.http.get('http://localhost:50892/api/sendmail/' + data);
     return r;
  }

}
