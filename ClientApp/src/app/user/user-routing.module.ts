import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BlockUserComponent } from './block-user/block-user.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { EditProfileComponent } from './edit-profile/edit-profile.component';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
