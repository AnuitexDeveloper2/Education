import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from "@angular/router";

import { AuthorRoutingModule } from './author-routing.module';
import { RemoveComponent } from './remove/remove.component';
import { UpdateComponent } from './update/update.component';
import { GetComponent } from './get/get.component';
import { MaterialModule } from "../material/material.module";
import { CreateComponent } from './create/create.component';
import { ReactiveFormsModule } from "@angular/forms";


@NgModule({
  declarations: [ 
    RemoveComponent,
    UpdateComponent,
    GetComponent,
    CreateComponent
  ],
  imports: [
    RouterModule,
    ReactiveFormsModule,
    CommonModule,
    AuthorRoutingModule,
    MaterialModule
  ]
})
export class AuthorModule { }
