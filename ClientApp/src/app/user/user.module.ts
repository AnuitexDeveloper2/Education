import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { UserRoutingModule } from "src/app/user/user-routing.module";
import { ProfileComponent } from 'src/app/user/profile/profile.component';
import { UsersComponent } from "src/app/user/users/users.component";
import { MaterialModule } from "src/app/material/material.module";
import { MyProfileComponent } from 'src/app/user/my-profile/my-profile.component';


@NgModule({
  declarations: [ ProfileComponent, UsersComponent, MyProfileComponent ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    UserRoutingModule,
    MaterialModule
  ]
})
export class UserModule { }
