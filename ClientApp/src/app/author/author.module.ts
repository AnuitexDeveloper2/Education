import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthorRoutingModule } from './author-routing.module';
import { CreateComponent } from './create/create.component';
import { RemoveComponent } from './remove/remove.component';
import { UpdateComponent } from './update/update.component';
import { GetComponent } from './get/get.component';


@NgModule({
  declarations: [CreateComponent, RemoveComponent, UpdateComponent, GetComponent],
  imports: [
    CommonModule,
    AuthorRoutingModule
  ]
})
export class AuthorModule { }
