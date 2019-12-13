import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { UserModel } from "../../models/user/UserModel";
import { FormControl } from '@angular/forms'
import { Observable } from 'rxjs';

@Injectable()
export class AccountService {
  
  constructor(private http:HttpClient) { }
register(user: UserModel,password:string){
  return this.http.post(`https://localhost:44309/api/account/register/?password=${password}`,user, { withCredentials: true })
  }

  
  signIn(email:string,password:string){
    return this.http.post(`https://localhost:44309/api/account/signIn/?password=${password}&email=${email}`, { withCredentials: true })
  }
}