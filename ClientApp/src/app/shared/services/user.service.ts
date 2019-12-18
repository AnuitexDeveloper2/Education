import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { UserFilterModel } from 'src/app/shared/models/user/UserFilterModel';
import { UserModel } from 'src/app/shared/models/user/UserModel';
import { UserModelItem } from '../models/user/UserModelItem';

@Injectable({
  providedIn: 'root'
})
export class UserService {
 
  constructor(private http:HttpClient) { }

  forgotPassword(email:string) {
    return this.http.post(`https://localhost:44309/api/user/forgotPassword/?email=${email}`,{withCredentials:true});
  }

  getUsers(userFilterModel:UserFilterModel):Observable<UserModel> {
    return this.http.post<UserModel>('https://localhost:44309/api/user/getUsers',userFilterModel)
  }

  changeUserStatus(id:number){
    return this.http.get(`https://localhost:44309/api/user/blockUser/?id=${id}`)
  }

  removeUser(id:number){
    return this.http.get(`https://localhost:44309/api/user/remove/?id=${id}`)
  }

  edit(userModelItem:UserModelItem){
    return this.http.post('https://localhost:44309/api/user/editProfile',userModelItem,{withCredentials:true});
  }

 

}
