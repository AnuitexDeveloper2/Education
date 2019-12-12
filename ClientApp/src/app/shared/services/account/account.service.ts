import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { UserModel } from "../../../shared/models/UserModel";
import { Observable } from 'rxjs';

@Injectable()
export class AccountService {
  constructor(private http:HttpClient) { }
register(user: UserModel):Observable<UserModel>{
  return this.http.post('http://localhost:50285/api/account/register',user)
  }
}