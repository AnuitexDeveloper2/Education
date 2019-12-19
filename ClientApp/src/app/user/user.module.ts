import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { UserRoutingModule } from "./user-routing.module";

import { BlockUserComponent } from 'src/app/user/block-user/block-user.component';
import { GetProfileComponent } from 'src/app/user/get-profile/get-profile.component';
import { RemoveComponent } from 'src/app/user/remove/remove.component';
import { EditProfileComponent } from 'src/app/user/edit-profile/edit-profile.component';
import { ForgotPasswordComponent } from 'src/app/user/forgot-password/forgot-password.component';
import { ChangePasswordComponent } from 'src/app/user/change-password/change-password.component';
import { GetUsersComponent } from 'src/app/user/get-users/get-users.component';
import { MaterialModule } from "src/app/material/material.module";


@NgModule({
  declarations: [BlockUserComponent, GetProfileComponent, RemoveComponent, EditProfileComponent, ForgotPasswordComponent, ChangePasswordComponent, GetUsersComponent ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    UserRoutingModule,
    MaterialModule
  ]
})
export class UserModule { }
