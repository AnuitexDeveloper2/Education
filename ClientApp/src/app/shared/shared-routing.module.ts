import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ErrorComponent } from './components/error/error.component';
import { RemoveComponent } from './components/remove/remove.component';


const routes: Routes = [
    { path: 'error', component: ErrorComponent },
    { path: 'remove', component: RemoveComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SharedRoutingModule { }