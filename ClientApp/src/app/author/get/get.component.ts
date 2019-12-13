import { Component, OnInit } from '@angular/core';
import { AuthorModel } from "../../shared/models/author/AuthorModel";

export interface PeriodicElement {
 id:number;
 name:string;
 product:string[]
}

const ELEMENT_DATA: AuthorModel[] = [
  
];
@Component({
  selector: 'app-get',
  templateUrl: './get.component.html',
  styleUrls: ['./get.component.css']
  
})

export class GetComponent implements OnInit {

  constructor() { }
  displayedColumns: string[] = ['id', 'name', 'product'];
  dataSource = ELEMENT_DATA;
  ngOnInit() {
  }

}
