import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { UserFilterModel } from 'src/app/shared/models/user/UserFilterModel';
import { UserModel } from 'src/app/shared/models/user/UserModel';
import { UserModelItem } from '../models/user/UserModelItem';
import { BaseModel } from '../models/Base/BaseModel';

@Injectable({
  providedIn: 'root'
})
export class UserService {
 
  constructor(private http:HttpClient) { }

  

  getUsers(userFilterModel:UserFilterModel):Observable<UserModel> {
    return this.http.post<UserModel>('https://localhost:44309/api/user/getUsers',userFilterModel)
  }

  changeUserStatus(id:number): Observable<BaseModel>{
    return this.http.get<BaseModel>(`https://localhost:44309/api/user/blockUser/?id=${id}`)
  }

  removeUser(id:number): Observable<BaseModel>{
    return this.http.get<BaseModel>(`https://localhost:44309/api/user/remove/?id=${id}`)
  }

  edit(userModelItem:UserModelItem): Observable<BaseModel>{
    return this.http.post<BaseModel>('https://localhost:44309/api/user/editProfile',userModelItem,{withCredentials:true});
  }


 

}
