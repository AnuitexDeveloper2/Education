import { Component, OnInit } from '@angular/core';
import { AuthorService } from 'src/app/shared/services/author/author.service';
import { AuthorModelItem } from 'src/app/shared/models/author/AuthorModelItem';
import { AuthorFilterModel } from 'src/app/shared/models/author/AuthorFilterModel';
import {PageEvent, MatSort, MatTableDataSource, MatDialog} from '@angular/material';
import { SortType } from 'src/app/shared/enums/SortType';
import { CreateComponent } from "src/app/author/create/create.component";
import { UpdateComponent } from "src/app/author/update/update.component";
import { RemoveComponent } from 'src/app/user/remove/remove.component';
import { ColumnName } from "src/app/shared/constants/column-name";
import { Filter } from 'src/app/shared/constants/Filter';
import { Direction } from 'src/app/shared/constants/direction';

@Component({
  selector: 'app-get-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css'],
  providers:[AuthorService]
})


export class AuthorsComponent implements OnInit {
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
    debugger;
    return this.authorService.get(this.authorFilter).subscribe(data=>{
      this.count = data.count;
      this.items = data.items;
      debugger;
    })
  }
  sortAuthors(event:MatSort) {


    if(event.direction == Direction.Asc)
    {
      this.authorFilter.sortType = SortType.Asc;
    }

    if(event.direction == Direction.Desc)
    {
      this.authorFilter.sortType = SortType.Desc;
    }
  
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
    const dialogRef = this.dialog.open(CreateComponent).afterClosed().subscribe(() => this.getAuthors());
    this.getAuthors();
  }

  edit(author:AuthorModelItem) {
    const dialogRef = this.dialog.open(UpdateComponent,{data:author}).afterClosed().subscribe(() => this.getAuthors());
  }

  remove(author:AuthorModelItem) {
    const dialogRef = this.dialog.open(RemoveComponent,{data:author,}).afterClosed().subscribe(() => this.getAuthors())
 }
  
 applyFilter(filtervalue:string) {
   this.authorFilter.searchString = filtervalue;
   this.authorFilter.pageNumber = Filter.one;
   this.pageIndex = Filter.zero;
   this.getAuthors();
 }



}