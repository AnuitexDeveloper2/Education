import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from "@angular/router";
import { ReactiveFormsModule,FormsModule } from "@angular/forms";
import { AuthorRoutingModule } from 'src/app/author/author-routing.module';
import { RemoveComponent } from 'src/app/author/remove/remove.component';
import { UpdateComponent } from 'src/app/author/update/update.component';
import { AuthorsComponent } from 'src/app/author/authors/authors.component';
import { MaterialModule } from "src/app/material/material.module";
import { CreateComponent } from 'src/app/author/create/create.component';


@NgModule({
  declarations: [ 
    RemoveComponent,
    UpdateComponent,
    AuthorsComponent,
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
