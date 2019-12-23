import { Component, OnInit } from '@angular/core';
import { AuthorService } from 'src/app/shared/services/author/author.service';
import { AuthorModelItem } from 'src/app/shared/models/author/AuthorModelItem';
import { AuthorFilterModel } from 'src/app/shared/models/author/AuthorFilterModel';
import {PageEvent, MatSort, MatTableDataSource, MatDialog} from '@angular/material';
import { SortType } from 'src/app/shared/enums/SortType';
import { CreateComponent } from "src/app/author/create/create.component";
import { UpdateComponent } from "src/app/author/update/update.component";
import { RemoveComponent } from '../remove/remove.component';

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
    this.displayedColumns = ['id', 'name', 'product','edit']
    this.authorFilter = new AuthorFilterModel();
  }
  ngOnInit() {
    this.authorFilter.pageSize = 10;
    this.authorFilter.pageNumber = 1;
    this.getAuthors();
  }

  
  getAuthors(){
    debugger;
    return this.authorService.get(this.authorFilter).subscribe(data=>{
      this.count = data.count;
      this.items = data.items;
      debugger;
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

  pagination(event: PageEvent) {
    debugger;
    this.authorFilter.pageSize = event.pageSize;
    this.pageIndex = event.pageIndex;
    this.authorFilter.pageNumber = this.pageIndex + 1; 
    this.getAuthors();
  }

  create(){
    const dialogRef = this.dialog.open(CreateComponent).afterClosed().subscribe(() => this.getAuthors());
    this.getAuthors();
  }

  edit(author:AuthorModelItem){
    debugger;
    const dialogRef = this.dialog.open(UpdateComponent,{data:author}).afterClosed().subscribe(() => this.getAuthors());
  }

  remove(author:AuthorModelItem){
    const dialogRef = this.dialog.open(RemoveComponent,{data:author}).afterClosed().subscribe(() => this.getAuthors())
 }
  
 applyFilter(filtervalue:string)
 {
   this.authorFilter.searchString = filtervalue;
   this.authorFilter.pageNumber = 1;
   this.pageIndex = 0;
   this.getAuthors();
   
 }



}
