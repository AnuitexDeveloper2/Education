import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  email: string;
  password:string;
  constructor(private http:HttpClient) { }
  forgotPassword(email): Observable<any>{
    return this.http.post('http://localhost:50285/api/user/forgotPassword?',email)
  }

  signIn(email,password):Observable<any>{
    return this.http.post('http://localhost:50285/api/account/signIn',email+password)
  }

}
