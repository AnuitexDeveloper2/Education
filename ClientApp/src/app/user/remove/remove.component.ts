import { Component, Inject, ViewChild } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { MAT_DIALOG_DATA } from '@angular/material';
import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';


@Component({
  selector: 'app-remove',
  templateUrl: './remove.component.html',
  styleUrls: ['./remove.component.css'],
  providers: [UserService]
})
export class RemoveComponent  {
    constructor(@Inject(MAT_DIALOG_DATA) public data: UserModelItem, private userService:UserService) { }

  remove(){

    this.userService.removeUser(this.data.id).subscribe();
  }

  

}
