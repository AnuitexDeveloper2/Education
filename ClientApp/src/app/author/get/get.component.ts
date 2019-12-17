import { Component, OnInit } from '@angular/core';
import { AuthorService } from 'src/app/shared/services/author/author.service';
import { AuthorModelItem } from 'src/app/shared/models/author/AuthorModelItem';
import { AuthorFilterModel } from 'src/app/shared/models/author/AuthorFilterModel';
import {MatPaginator, MatSort, MatTableDataSource, MatDialog} from '@angular/material';
import { BaseFilterModel } from 'src/app/shared/models/Base/BaseFilterModel';

@Component({
  selector: 'app-get',
  templateUrl: './get.component.html',
  styleUrls: ['./get.component.css'],
  providers:[AuthorService]
})

export class GetComponent implements OnInit {

  authorFilter : BaseFilterModel;
  items: Array<AuthorModelItem>;
  count: number;
  pageNumber: number;
  pageSize: number;
  public dataSource = new MatTableDataSource();
  displayedColumns: string[];

  constructor(private authorService:AuthorService,public dialog:MatDialog) { 
    this.displayedColumns = ['id', 'name', 'product']
    this.authorFilter = new BaseFilterModel();
  }
  ngOnInit() {
    debugger;
    this.getAuthors();
  }

  
  getAuthors(){
    return this.authorService.get(this.authorFilter).subscribe(data=>{
      this.count = data.count;
      this.items = data.items;
    })
  }

  sortAuthors() {
   this.authorFilter.sortType
    this.getAuthors();
  }

}
