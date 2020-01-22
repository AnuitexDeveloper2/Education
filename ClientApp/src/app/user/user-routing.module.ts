import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfileComponent } from 'src/app/user/profile/profile.component';
import { UsersComponent } from 'src/app/user/users/users.component'
import { MyProfileComponent } from 'src/app/user/my-profile/my-profile.component';

export const routes: Routes = [
  { path: 'profile', component: ProfileComponent },
  { path: 'users', component: UsersComponent },
  { path: 'get-profile', component: MyProfileComponent}
]
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }

