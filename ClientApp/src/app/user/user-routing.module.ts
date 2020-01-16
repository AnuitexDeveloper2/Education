import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfileComponent } from 'src/app/user/profile/profile.component';
import { UsersComponent } from 'src/app/user/users/users.component'

export const routes: Routes = [
  { path: 'profile', component:ProfileComponent },
  { path: 'users', component:UsersComponent }
]
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
