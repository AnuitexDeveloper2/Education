import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GetComponent } from "../author/get/get.component";
import { RemoveComponent } from "../author/remove/remove.component";
import { UpdateComponent } from "../author/update/update.component";
import { CreateComponent } from './create/create.component';

export const routes: Routes = [
{ path:'create', component:CreateComponent },
{ path:'get', component:GetComponent },
{ path:'remove',component:RemoveComponent },
{ path:'update',component:UpdateComponent }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthorRoutingModule { }
