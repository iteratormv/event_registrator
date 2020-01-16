import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { getBaseUrl } from 'src/main';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class UsersService implements OnInit {
  public users:any;
  public isa:booleanReturn;
  currentUser: string;
  currentConfirmedUser:string

  ngOnInit() {
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string)
   { 
//    console.log("start constructor service");
    var burl = getBaseUrl();
    this.http.get(burl + 'api/users').subscribe((data) =>
     {
       this.users=data;
 //      console.log("in subscribe users constructor service");
 //      console.log(data);
      });
      this.currentUser = "guest";
      this.currentConfirmedUser = "guest";
//     console.log("end constructor service");
   }
  public  getUsers():Array<any>{
//    console.log("get users in service" + this.users);
//   if(this.users!=null) {}
//    console.log(this.users)
    return this.users;
  }
  public getIsa():booleanReturn{
    if(this.isa!=null)
 //    console.log(" get isa = " + this.isa.retData)
//    else console.log(" get isa = " + this.isa)
    return this.isa;
  }
  public isContainUser1(user:string): any {
      var burl = getBaseUrl();
      return this.http.get<booleanReturn>(burl + 'api/AddUserByTocken/' + user)
    }
  public isContainUser2(user:string): any {
      var burl = getBaseUrl();
      return this.http.get<booleanReturn>(burl + 'api/AddUserByTocken/' + user)
      .subscribe(     
     (data:booleanReturn)=>
      {
        let temp = data;
        this.isa=data;
//       alert(this.isa.retData + " " + data.retData);
//       console.log(this.isa.retData + " containuser2 " + data.retData)
       if(data!=null)
        return this.isa;
      })

  }
  public isContainUser3(user:string): boolean {
      this.users.forEach(element => {
        if(element == user) return true;
      });
      return false;
  }
  public async isContainUser(user:string): Promise<boolean> {
    var burl = getBaseUrl();
    var d = await this.http.get<booleanReturn>(burl + 'api/AddUserByTocken/' + user)
    .toPromise();
    this.http.get<booleanReturn>(burl + 'api/AddUserByTocken/' + user)
    .subscribe(     
      (data:booleanReturn)=>
       {
         let temp = data;
         this.isa=data;
  //      console.log(this.isa.retData + " containuser " + data.retData)
        if(data!=null)
         return this.isa;
       })
    return d.retData;
  }

  public sendmail(datau:string) : string{
    let r:string;
    var burl = getBaseUrl();
    this.http.get(burl + 'api/sendmail/' + datau).subscribe(result => {
      r = result.toString();
    }, error => console.error(error));
     return r;
  }

  async initUsers():Promise<boolean>
  { 
   var burl = getBaseUrl();
   var q = await this.http.get(burl + 'api/users').subscribe((data) =>
    {
      this.users=data;
     });
     if(q) return true;
     else return false;
  }
}

export interface booleanReturn{
  retData: boolean;
}

