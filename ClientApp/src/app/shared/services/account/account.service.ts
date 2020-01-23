import { Injectable, Component } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { UserModelItem } from "src/app/shared/models/user/UserModelItem";
import { Observable } from 'rxjs';
import { BaseModel } from 'src/app/shared/models/Base/BaseModel';
import { environment } from "src/environments/environment";
@Injectable()
export class AccountService {
  
  constructor(private http:HttpClient ) { }

  getToken(){
  }

register(user: UserModelItem):Observable<BaseModel>{
  return this.http.post<BaseModel>( environment.baseUrl + `account/register`,user, { withCredentials: true })
  }
  
  signIn(email:string,password:string):Observable<UserModelItem>{
    return this.http.post<UserModelItem>(environment.baseUrl + `account/signIn/?password=${password}&email=${email}`, { withCredentials: true })
  }

  forgotPassword(email:string):Observable<BaseModel> {
    return this.http.post<BaseModel>(environment.baseUrl + `account/forgotPassword/?email=${email}`,{withCredentials:true});
  }

  logOut(user: UserModelItem) {
    return this.http.post(environment.baseUrl + 'account/signOut/',user)
  }

  

}