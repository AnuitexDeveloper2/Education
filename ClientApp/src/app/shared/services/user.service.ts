import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  email: string;
  constructor(private http:HttpClient) { }
  forgotPassword(){
    return this.http.get(' http://localhost:50285/api/user/forgotPassword?email=${email}')
  }

}
