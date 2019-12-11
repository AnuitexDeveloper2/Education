import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { UserModel } from "../../../shared/models/UserModel";

@Injectable()
export class AccountService {
  constructor(private http:HttpClient) { }
register(user: UserModel){
  return this.http.post(' http://localhost:44309/api/account/register',user)
}
}
