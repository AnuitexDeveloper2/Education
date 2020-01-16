import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorsComponent } from "src/app/author/authors/authors.component";
import { CreateComponent } from 'src/app/author/create/create.component';

export const routes: Routes = [
{ path:'create', component:CreateComponent },
{ path:'authors', component:AuthorsComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthorRoutingModule { }
