import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { BlockUserComponent } from './block-user/block-user.component';
import { GetProfileComponent } from './get-profile/get-profile.component';
import { RemoveComponent } from './remove/remove.component';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { GetComponent } from './get/get.component';


@NgModule({
  declarations: [BlockUserComponent, GetProfileComponent, RemoveComponent, EditProfileComponent, ForgotPasswordComponent, ChangePasswordComponent, GetComponent],
  imports: [
    CommonModule,
    UserRoutingModule
  ]
})
export class UserModule { }
