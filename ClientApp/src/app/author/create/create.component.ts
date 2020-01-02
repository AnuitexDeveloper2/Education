import { Component, OnInit,Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { AuthorService } from 'src/app/shared/services/author/author.service';
import { AuthorModelItem } from 'src/app/shared/models/author/AuthorModelItem';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
  providers: [AuthorService]
})
export class CreateComponent  {

  author: AuthorModelItem;

  constructor(@Inject(MAT_DIALOG_DATA) public data: string, private authorService: AuthorService) { 
    this.author = new AuthorModelItem;
  }

  save(){
    this.authorService.save(this.author).subscribe();
  }

 
}
