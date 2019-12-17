import { Component, OnInit,ViewChild } from '@angular/core';
import { AuthorService } from 'src/app/shared/services/author/author.service';
import { AuthorModelItem } from 'src/app/shared/models/author/AuthorModelItem';
import { AuthorFilterModel } from 'src/app/shared/models/author/AuthorFilterModel';
import {PageEvent, MatSort, MatTableDataSource, MatDialog} from '@angular/material';
import { BaseFilterModel } from 'src/app/shared/models/Base/BaseFilterModel';
import { SortType } from 'src/app/shared/enums/SortType';

@Component({
  selector: 'app-get',
  templateUrl: './get.component.html',
  styleUrls: ['./get.component.css'],
  providers:[AuthorService]
})

export class GetComponent implements OnInit {

  pageIndex:number;
  authorFilter : AuthorFilterModel;
  items: Array<AuthorModelItem>;
  count: number;
  pageNumber: number;
  pageSize: number;
  public dataSource = new MatTableDataSource();
  displayedColumns: string[];

  constructor(private authorService:AuthorService,public dialog:MatDialog) { 
    this.displayedColumns = ['id', 'name', 'product']
    this.authorFilter = new AuthorFilterModel();
  }
  ngOnInit() {
    this.getAuthors();
  }

  
  getAuthors(){
    return this.authorService.get(this.authorFilter).subscribe(data=>{
      this.count = data.count;
      this.items = data.items;
    })
  }
  sortAuthors(event:MatSort) {


    if(event.direction =='asc')
    {
      this.authorFilter.sortType = SortType.Asc;
    }

    if(event.direction == 'desc')
    {
      this.authorFilter.sortType = SortType.Desc;
    }
  
    this.getAuthors();
  }

  getServerData(event: PageEvent) {
    this.pageIndex = event.pageIndex;
    this.authorFilter.pageSize = event.pageSize;
    this.authorFilter.pageNumber = this.pageNumber;
    this.getAuthors();
  }

}
