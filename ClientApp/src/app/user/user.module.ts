import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { UserRoutingModule } from "./user-routing.module";
import { RemoveComponent } from 'src/app/user/remove/remove.component';
import { ProfileComponent } from 'src/app/user/profile/profile.component';
import { UsersComponent } from "src/app/user/users/users.component";
import { MaterialModule } from "src/app/material/material.module";


@NgModule({
  declarations: [ RemoveComponent, ProfileComponent, UsersComponent ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    UserRoutingModule,
    MaterialModule
  ]
})
export class UserModule { }
