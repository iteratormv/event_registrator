import { Injectable, OnInit, Input, OnChanges } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { getBaseUrl } from 'src/main';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';
import { CompileShallowModuleMetadata } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})

export class UsersService implements OnInit, OnChanges   {

  ngOnChanges(changes: import("@angular/core").SimpleChanges): void {
 //   console.log("sevice ngonchanged");
 //   this.userName = this.currentUser;
 //console.log(changes);
  }

  public users:any;
  public roles:any;
  public userInRoles:any;
  public isa:booleanReturn;

  currentUser: string;
  currentConfirmedUser:string
  roleCurrentConfermedUser:string;

  public currentConfirmedUserObject:User;

//  @Input() userName: string;

  ngOnInit() {
  //  console.log("service on init")
  }
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string)
   { 
    this.initUsers();
    this.currentUser = "guest";
    this.currentConfirmedUser = "guest";
    this.roleCurrentConfermedUser = "guest";
    console.log("end constructor service");
 //   console.log(this.currentConfirmedUserObject);
   var burl = getBaseUrl();
   http.get(burl + 'api/users/2').subscribe(res=>{
     var temp:any = res;
     this.currentConfirmedUserObject = temp;
     console.log(this.currentConfirmedUserObject);
   });
   }
   public getRoleCurrentConfirmedUser():string{
     return this.roleCurrentConfermedUser;
   }
   public getCurrentConfermedUser():string{
    // console.log("service getcurrent confermeduser")
    this.getUserObjectByName(this.currentConfirmedUser);
    console.log(this.currentConfirmedUserObject);
     console.log(this.currentConfirmedUserObject);
     if(this.currentConfirmedUserObject!=null) {
      this.initRoleByUser(this.currentConfirmedUserObject);
     }
     return this.currentConfirmedUser;
   }
  public  getUsers():Array<User>{
//    console.log("get users in service" + this.users);
//   if(this.users!=null) {}
//    console.log(this.users)
    return this.users;
  }
  public getRoles():Array<Role>{
    return this.roles;
  }
  public getUserInRoles():Array<UserInRole>{
    return this.userInRoles;
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
  public sendmailpost(u:User) : string{
    var burl = getBaseUrl();
    const body = {"Email": u.email, "Password": u.password, "firstName":u.firstName, "surName":u.surName};
//    console.log(burl + 'api/sendmail')
//    console.log('http://localhost:50892/api/SendMaiL')
    this.http.post(burl + 'api/sendmail', body).subscribe(
      () => {},
      error => console.log(error)
  );
     return "ok";
  }
  async initUsers():Promise<boolean>
  { 
   var burl = getBaseUrl();
   var q = await this.http.get(burl + 'api/users').subscribe((data) =>{
    this.users=data;
  //  console.log(this.users);
   });
   var qr = await this.http.get(burl + 'api/roles').subscribe((data)=>{
     this.roles = data;
 //    console.log(this.roles);
   }); 
   var quir = await this.http.get(burl + 'api/userinroles').subscribe((data)=>{
     this.userInRoles = data;
   //  console.log(this.userInRoles);
   });
 //  console.log("initusers");
  // console.log(q);
 //  console.log(qr);
  // console.log(quir);
if(this.currentUser == "guest"){
  this.http.get(burl + 'api/users/2').subscribe(res=>{
    var temp:any = res;
    this.currentConfirmedUserObject = temp;
    console.log(this.currentConfirmedUserObject);
  });
}


     if(q) return true;
     else return false;
  }
  getUserObjectByName(username:string):Promise<User>{
 //   console.log("getobjectbyname");
    let us = this.getUsers();
    if(us==null) return null;
    us.forEach(u=>{
  //    console.log(u.firstName + " compare " + username);
      if(u.firstName == username) {
   //     console.log(u);
        return u;
      }
    })
    return null;
  }
  async initRoleByUser(u:User):Promise<Role>{
 //   console.log("initrole start");
//    console.log(u)
    let rs = this.getRoles();
 //   console.log(rs);
    let uirs = this.getUserInRoles();
 //   console.log(uirs);
    if(uirs==null) return null;
    uirs.forEach(uir=>{
  //    console.log(uir.userId + " compare " + u.id);
      if(uir.userId == u.id){
        if(rs==null) return null;
        rs.forEach(r=>{
  //        console.log(r.id + " compare " + uir.roleId);
          if(r.id == uir.roleId) {
  //          console.log("initrolebyuser return role")
   //         console.log(r);
            this.roleCurrentConfermedUser = r.name;
   //         console.log(this.roleCurrentConfermedUser)
            return r;
          }
        })
      }
    });
    return null;
  }
  async setGuest(){
 //   console.log("setguest start")
    this.currentUser = "guest";
    this.currentConfirmedUser = "guest";
    this.roleCurrentConfermedUser = "guest";
    this.currentConfirmedUserObject = await this.getUserObjectByName("guest");
  //  console.log("setguest")
  //  console.log(this.currentConfirmedUserObject);
  //  this.initRoleByUser(this.currentConfirmedUserObject);
  }
  addUser(user:User){
    var burl = getBaseUrl();
    this.http.post(burl + 'api/users', user).subscribe((data)=>{
      console.log(data);
      this.initUsers();
    });  
  }
  addUserInRole(uir:UserInRole){
    var burl = getBaseUrl();
    this.http.post(burl + 'api/userinroles', uir).subscribe((data)=>{
      console.log(data);
      this.initUsers();
    })
  }
}
export interface booleanReturn{
  retData: boolean;
}
export interface User{
  id:number;
  firstName:string;
  surName:string;
  email:string;
  password:string;
}
export interface Role{
  id:number;
  name:string;
  canSendMail:boolean;
  canAdministrate:boolean;
}
export interface UserInRole{
  id:number;
  userId:number;
  roleId:number;
}
