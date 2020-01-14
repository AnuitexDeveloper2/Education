import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PrintingEditionsComponent } from 'src/app/printing-edition/printing-editions/printing-editions.component';
import { CreateComponent } from 'src/app/printing-edition/create/create.component';
import { RemoveComponent } from 'src/app/printing-edition/remove/remove.component';
import { MainComponent } from 'src/app/printing-edition/mainPage/main.component';
import { DetailsComponent } from './details/details.component';

export const routes: Routes = [
  { path: 'printing-editions', component: PrintingEditionsComponent },
  { path: 'create', component: CreateComponent },
  { path: 'remove', component: RemoveComponent },
  { path: 'main', component: MainComponent },
  { path: 'details', component: DetailsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PrintingEditionRoutingModule { }
