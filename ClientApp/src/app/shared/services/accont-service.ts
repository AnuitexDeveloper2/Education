import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserModel } from "../models/UserModel";
@Injectable()
export class AccountService {
  constructor(private http: HttpClient) {
  }
  register(userModel:UserModel): Observable<UserModel>{
    return this.http.post<UserModel>('http://localhost:44309/api/account/register',userModel);
  }
}