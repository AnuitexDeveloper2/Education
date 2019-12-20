import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule,ReactiveFormsModule } from "@angular/forms";
import { MaterialModule } from "src/app/material/material.module";
import { PrintingEditionRoutingModule } from './printing-edition-routing.module';
import { CreateComponent } from 'src/app/printing-edition/create/create.component';
import { RemoveComponent } from 'src/app/printing-edition/remove/remove.component';
import { UpdateComponent } from 'src/app/printing-edition/update/update.component';
import { PrintingEditionsComponent } from 'src/app/printing-edition/printing-editions/printing-editions.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [CreateComponent, RemoveComponent, UpdateComponent, PrintingEditionsComponent],
  imports: [
    CommonModule,
    PrintingEditionRoutingModule,
    RouterModule,
    PrintingEditionRoutingModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    PrintingEditionRoutingModule,
    MaterialModule
  ]
})
export class PrintingEditionModule { }
