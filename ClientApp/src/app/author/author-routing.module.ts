import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorsComponent } from "src/app/author/authors/authors.component";
import { RemoveComponent } from "src/app/author/remove/remove.component";
import { CreateComponent } from 'src/app/author/create/create.component';

export const routes: Routes = [
{ path:'create', component:CreateComponent },
{ path:'authors', component:AuthorsComponent },
{ path:'remove',component:RemoveComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthorRoutingModule { }
