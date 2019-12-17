import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { UserFilterModel } from '../models/user/UserFilterModel';
import { UserModel } from '../models/user/UserModel';
import { UserModelItem } from '../models/user/UserModelItem';

@Injectable({
  providedIn: 'root'
})
export class UserService {
 
  constructor(private http:HttpClient) { }

  ForgotPassword(email:string) {
    return this.http.post(`https://localhost:44309/api/user/forgotPassword/?email=${email}`,{withCredentials:true});
  }

  getUsers(userFilterModel:UserFilterModel):Observable<UserModel> {
    return this.http.post<UserModel>('https://localhost:44309/api/user/getUsers',userFilterModel)
  }

  changeUserStatus(id:number){
    return this.http.get(`https://localhost:44309/api/user/blockUser/?id=${id}`)
  }

 

}
