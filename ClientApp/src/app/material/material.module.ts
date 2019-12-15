import { NgModule } from '@angular/core';

import {  MatButtonModule,
  MatPaginatorModule,
  MatTableModule,
  MatDialogModule,
  MatInputModule,
  MatSortModule,
  MatSlideToggleModule,
  MatSelectModule 
} from "@angular/material";

const MaterialComponent =[
 MatPaginatorModule,
 MatTableModule,
 MatDialogModule,
 MatInputModule,
 MatSortModule,
 MatSlideToggleModule,
 MatSelectModule 
]


@NgModule({
  imports:[MaterialComponent],
  exports:[MaterialComponent]
})
export class MaterialModule { }
