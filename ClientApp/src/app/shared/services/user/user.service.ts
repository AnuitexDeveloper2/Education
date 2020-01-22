import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { UserFilterModel } from 'src/app/shared/models/user/UserFilterModel';
import { UserModel } from 'src/app/shared/models/user/UserModel';
import { BaseModel } from 'src/app/shared/models/Base/BaseModel';
import { UserProfileEditModel } from 'src/app/shared/models/user/UserProfileEditModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
 
  constructor(private http:HttpClient) { }

  

  getUsers(userFilterModel:UserFilterModel):Observable<UserModel> {
    return this.http.post<UserModel>(environment.baseUrl + 'user/getUsers',userFilterModel)
  }

  changeUserStatus(id:number): Observable<BaseModel> {
    return this.http.get<BaseModel>(environment.baseUrl + `user/blockUser/?id=${id}`)
  }

  removeUser(id:number): Observable<BaseModel> {
    return this.http.get<BaseModel>(environment.baseUrl + `user/remove/?id=${id}`)
  }

  edit(userEditModel:UserProfileEditModel): Observable<BaseModel> {
    debugger;
    return this.http.post<BaseModel>(environment.baseUrl +'user/editProfile',userEditModel,{withCredentials:true});
  }

  changePassword(id: number, oldPassword: string, newPassword): Observable<BaseModel> {
    return this.http.get<BaseModel>(environment.baseUrl + `user/changePassword/?id=${id}&oldPassword=${oldPassword}&newPassword=${newPassword}`)
  }

}
