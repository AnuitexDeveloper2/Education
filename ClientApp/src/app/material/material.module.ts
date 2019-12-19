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
  MatTooltipModule
} from "@angular/material";

const MaterialComponent =[
 MatPaginatorModule,
 MatTableModule,
 MatDialogModule,
 MatInputModule,
 MatSortModule,
 MatSlideToggleModule,
 MatSelectModule,
 MatFormFieldModule,
 MatTooltipModule,
 MatButtonModule
]


@NgModule({
  imports:[MaterialComponent],
  exports:[MaterialComponent]
})
export class MaterialModule { }
