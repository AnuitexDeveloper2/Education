import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from "@angular/router";
import { ReactiveFormsModule,FormsModule } from "@angular/forms";
import { AuthorRoutingModule } from 'src/app/author/author-routing.module';
import { RemoveComponent } from 'src/app/author/remove/remove.component';
import { UpdateComponent } from 'src/app/author/update/update.component';
import { GetComponent } from 'src/app/author/get/get.component';
import { MaterialModule } from "src/app/material/material.module";
import { CreateComponent } from 'src/app/author/create/create.component';


@NgModule({
  declarations: [ 
    RemoveComponent,
    UpdateComponent,
    GetComponent,
    CreateComponent
  ],
  imports: [
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    AuthorRoutingModule,
    MaterialModule
  ]
})
export class AuthorModule { }
