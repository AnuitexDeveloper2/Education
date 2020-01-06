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
  MatTooltipModule,
  MatCheckboxModule,
  MatIconModule,
} from "@angular/material";

const MaterialComponent =[
 MatIconModule,
 MatCheckboxModule,
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
