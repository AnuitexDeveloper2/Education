import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { UserModel } from "../../../shared/models/UserModel";
import { Observable } from 'rxjs';

@Injectable()
export class AccountService {
  email:string;
  constructor(private http:HttpClient) { }
register(user: UserModel){
  return this.http.post(`https://localhost:44309/api/account/register/?email=${this.email}`,user, { withCredentials: true })
  }

  
  signIn(email:string,password:string):Observable<any>{
    return this.http.post('http://localhost:50285/api/account/signIn',JSON.stringify(email +password))
  }
}