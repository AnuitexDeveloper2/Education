import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { ConfirmEmailComponent } from './confirm-email/confirm-email.component';
import { SignOutComponent } from './sign-out/sign-out.component';


export const routes: Routes = [
      { path: 'sign-in', component:SignInComponent },
      { path: 'register', component:RegisterComponent },
      { path: 'confirm-email', component:ConfirmEmailComponent },
      { path: 'sign-out', component:SignOutComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
