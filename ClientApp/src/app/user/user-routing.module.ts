import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BlockUserComponent } from './block-user/block-user.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { GetProfileComponent } from './get-profile/get-profile.component';

export const routes: Routes = [
  { path: 'block-user', component:BlockUserComponent },
  { path: 'change-Password', component:ChangePasswordComponent},
  { path: 'edit-profile', component:EditProfileComponent },
  { path: 'forgot-password', component:ForgotPasswordComponent },
  { path: 'get-profile', component:GetProfileComponent }
]
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
