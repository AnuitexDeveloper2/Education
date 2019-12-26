import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { UserModelItem } from "src/app/shared/models/user/UserModelItem";

@Injectable()
export class AccountService {
  
  constructor(private http:HttpClient) { }
register(user: UserModelItem){
  debugger;
  return this.http.post(`https://localhost:44309/api/account/register/?password`,user, { withCredentials: true })
  }

  
  signIn(email:string,password:string){
    return this.http.post(`https://localhost:44309/api/account/signIn/?password=${password}&email=${email}`, { withCredentials: true })
  }
}