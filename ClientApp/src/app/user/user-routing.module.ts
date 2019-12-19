import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BlockUserComponent } from 'src/app/user/block-user/block-user.component';
import { ChangePasswordComponent } from 'src/app/user/change-password/change-password.component';
import { EditProfileComponent } from 'src/app/user/edit-profile/edit-profile.component';
import { ForgotPasswordComponent } from 'src/app/user/forgot-password/forgot-password.component';
import { GetProfileComponent } from 'src/app/user/get-profile/get-profile.component';
import { GetUsersComponent } from 'src/app/user/get-users/get-users.component'
import { RemoveComponent } from 'src/app/user/remove/remove.component';

export const routes: Routes = [
  { path: 'remove', component: RemoveComponent },
  { path: 'block-user', component:BlockUserComponent },
  { path: 'change-Password', component:ChangePasswordComponent},
  { path: 'edit-profile', component:EditProfileComponent },
  { path: 'forgot-password', component:ForgotPasswordComponent },
  { path: 'get-profile', component:GetProfileComponent },
  { path: 'get-users', component:GetUsersComponent }
]
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
