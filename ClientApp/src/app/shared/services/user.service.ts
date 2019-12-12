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

  ForgotPassword(email:string) {
    return this.http.get(`https://localhost:44309/api/user/forgotPassword/?email=${email}`)
  }

 

}
