import { Component, OnInit } from '@angular/core';
import { AuthorModel } from "../../shared/models/author/AuthorModel";



const ELEMENT_DATA: AuthorModel[] = [
  {id: 1, name: 'Hydrogen', product: 'Barbara'},
  ]
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
