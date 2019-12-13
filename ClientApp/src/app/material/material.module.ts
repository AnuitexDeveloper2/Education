import { NgModule } from '@angular/core';
import { MatPaginatorModule } from '@angular/material';
import { MatTableModule } from "@angular/material";

const MaterialComponent =[
MatPaginatorModule,
MatTableModule
]


@NgModule({
  imports:[MaterialComponent],
  exports:[MaterialComponent]
})
export class MaterialModule { }
