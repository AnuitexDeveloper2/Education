import { Component, OnInit } from '@angular/core';
import {PageEvent, MatSort, MatTableDataSource, MatDialog} from '@angular/material';
import { AuthorService } from 'src/app/shared/services/author/author.service';
import { AuthorModelItem } from 'src/app/shared/models/author/AuthorModelItem';
import { AuthorFilterModel } from 'src/app/shared/models/author/AuthorFilterModel';
import { SortType } from 'src/app/shared/enums/SortType';
import { CreateComponent } from "src/app/author/create/create.component";
import { ColumnName } from "src/app/shared/constants/column-name";
import { Filter } from 'src/app/shared/constants/Filter';
import { CreateEdit } from 'src/app/shared/enums/CreateEdit';
import { RemoveComponent } from 'src/app/shared/components/remove/remove.component';
@Component({
  selector: 'app-get-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css'],
  providers:[AuthorService]
})


export class AuthorsComponent implements OnInit {
  path: CreateEdit;
  pageIndex: number;
  authorFilter: AuthorFilterModel;
  items: Array<AuthorModelItem>;
  count: number;
  pageNumber: number;
  pageSize: number;
  public dataSource = new MatTableDataSource();
  displayedColumns: string[];
  
  constructor( private authorService:AuthorService,public dialog:MatDialog ) { 
    this.displayedColumns = [ ColumnName.id, ColumnName.Name, ColumnName.Product, ColumnName.Edit]
    this.authorFilter = new AuthorFilterModel();
  }

  ngOnInit() {
    this.authorFilter.pageSize = Filter.ten;
    this.authorFilter.pageNumber = Filter.one;
    this.getAuthors();
  }

  getAuthors() {
    return this.authorService.get(this.authorFilter).subscribe(data=>{
      this.count = data.count;
      this.items = data.items;
    })
  }

  sortAuthors(event:MatSort) {
    this.authorFilter.sortType = SortType[event.direction];
    this.getAuthors();
  }

  movePage(event: PageEvent) {
    debugger;
    this.authorFilter.pageSize = event.pageSize;
    this.pageIndex = event.pageIndex;
    this.authorFilter.pageNumber = this.pageIndex + Filter.one; 
    this.getAuthors();
  }

  create() {
    debugger;
    let author = new AuthorModelItem();
    author.id = 0;
    const dialogRef = this.dialog.open(CreateComponent,{data:author}).afterClosed().subscribe(() => this.getAuthors());
    this.getAuthors();
  }

  edit(author:AuthorModelItem) {
    const dialogRef = this.dialog.open(CreateComponent,{data:author}).afterClosed().subscribe(() => this.getAuthors());
  }

 remove(author: AuthorModelItem) {
  let dialogRef = this.dialog.open(RemoveComponent, {data: {pageName: 'author', name: author.name}})
  .afterClosed().subscribe(data => {
    if (data) {
    this.authorService.remove(author.id).subscribe(() => this.getAuthors());
    }
  });
}
  
 applyFilter(filtervalue:string) {
   this.authorFilter.searchString = filtervalue;
   this.authorFilter.pageNumber = Filter.one;
   this.pageIndex = Filter.zero;
   this.getAuthors();
 }



}
