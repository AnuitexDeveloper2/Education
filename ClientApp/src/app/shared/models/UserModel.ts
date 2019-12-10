import { OnInit } from '@angular/core';

export class UserModel {
   constructor(
       public UserName?: string,
       public firstName?: string,
       public lastName?: string,
       public email?: string,
       public id?: number,
       public Role?: string
   ){}
}