import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import {  MatFormFieldModule } from "@angular/material";
import { AccountRoutingModule } from 'src/app/account/account-routing.module';
import { RegisterComponent } from 'src/app/account/register/register.component';
import { SignInComponent } from 'src/app/account/sign-in/sign-in.component';
import { SignOutComponent } from 'src/app/account/sign-out/sign-out.component';
import { ConfirmEmailComponent } from 'src/app/account/confirm-email/confirm-email.component';


@NgModule({
  declarations: [RegisterComponent, SignInComponent, SignOutComponent, ConfirmEmailComponent],
  imports: [
    MatFormFieldModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    AccountRoutingModule  ]
})
export class AccountModule { }
