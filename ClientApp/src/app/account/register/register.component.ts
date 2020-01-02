import { Component } from '@angular/core';
import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';
import { AccountService } from 'src/app/shared/services/account/account.service';
import { BaseModel } from 'src/app/shared/models/Base/BaseModel';
import { MatDialog } from '@angular/material';
import { ErrorComponent } from '../error/error.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers:[AccountService]
})
export class RegisterComponent {
  user: UserModelItem;
  baseModel: BaseModel;
  constructor(private accountService: AccountService,public dialog:MatDialog) {
    this.user = new UserModelItem();
    this.baseModel = new BaseModel();
   }

   
  save(){
  this.accountService.register(this.user).subscribe(data => {
      this.baseModel.errors = data.errors
      if(this.baseModel.errors.length>0){
       this.dialog.open(ErrorComponent,{data:this.baseModel.errors})
      }

  })
 }
}
