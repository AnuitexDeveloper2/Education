import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule,ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from '@angular/router';
import { MaterialModule } from "src/app/material/material.module";
import { PrintingEditionRoutingModule } from 'src/app/printing-edition/printing-edition-routing.module';
import { CreateComponent } from 'src/app/printing-edition/create/create.component';
import { PrintingEditionsComponent } from 'src/app/printing-edition/printing-editions/printing-editions.component';
import { MainComponent } from 'src/app/printing-edition/mainPage/main.component';
import { DetailsComponent } from 'src/app/printing-edition/details/details.component';


@NgModule({
  declarations: [CreateComponent, PrintingEditionsComponent, MainComponent, DetailsComponent],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    PrintingEditionRoutingModule,
    MaterialModule
  ]
})
export class PrintingEditionModule { }
