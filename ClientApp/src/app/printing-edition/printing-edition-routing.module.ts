import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PrintingEditionsComponent } from 'src/app/printing-edition/printing-editions/printing-editions.component';
import { CreateComponent } from 'src/app/printing-edition/create/create.component';
import { RemoveComponent } from 'src/app/printing-edition/remove/remove.component';
import { UpdateComponent } from 'src/app/printing-edition/update/update.component';

export const routes: Routes = [
  {path: 'printing-editions', component: PrintingEditionsComponent},
  {path: 'create', component: CreateComponent},
  {path: 'remove', component: RemoveComponent},
  {path: 'update', component: UpdateComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PrintingEditionRoutingModule { }
