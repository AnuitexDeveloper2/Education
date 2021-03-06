import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from 'src/app/account/register/register.component';
import { SignInComponent } from 'src/app/account/sign-in/sign-in.component';
import { SignOutComponent } from 'src/app/account/sign-out/sign-out.component';
import { ConfirmEmailComponent } from 'src/app/account/confirm-email/confirm-email.component';
import { ForgotPasswordComponent } from 'src/app/account/forgot-password/forgot-password.component';


export const routes: Routes = [
      { path: 'sign-in', component: SignInComponent },
      { path: 'confirm-email', component: ConfirmEmailComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'forgot-password', component: ForgotPasswordComponent },
      { path: 'sign-out', component: SignOutComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
