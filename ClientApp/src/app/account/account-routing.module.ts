import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignOutComponent } from './sign-out/sign-out.component';
import { ConfirmEmailComponent } from './confirm-email/confirm-email.component';


export const routes: Routes = [
      { path: 'sign-in', component:SignInComponent },
      { path: 'confirm-email', component:ConfirmEmailComponent },
      { path: 'register', component:RegisterComponent },
      { path: 'sign-out', component:SignOutComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
