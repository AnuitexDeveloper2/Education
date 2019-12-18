import { NgModule } from '@angular/core';

import {  MatButtonModule,
  MatPaginatorModule,
  MatTableModule,
  MatDialogModule,
  MatInputModule,
  MatSortModule,
  MatSlideToggleModule,
  MatSelectModule,
  MatFormFieldModule,
} from "@angular/material";

const MaterialComponent =[
 MatPaginatorModule,
 MatTableModule,
 MatDialogModule,
 MatInputModule,
 MatSortModule,
 MatSlideToggleModule,
 MatSelectModule,
 MatFormFieldModule
]


@NgModule({
  imports:[MaterialComponent],
  exports:[MaterialComponent]
})
export class MaterialModule { }
