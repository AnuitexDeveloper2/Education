import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from "@angular/material";
import { FormControl } from "@angular/forms";
import { AuthorService } from "src/app/shared/services/author/author.service";
import { AuthorModelItem } from 'src/app/shared/models/author/AuthorModelItem';


@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css'],
  providers:[AuthorService]
})
export class UpdateComponent  {

  authorName = new FormControl();
  constructor(@Inject(MAT_DIALOG_DATA) public data: AuthorModelItem,private authorService:AuthorService) { }

  edit(){
    let name = this.authorName.value
    this.authorService.edit(this.data.id,name).subscribe();
  }

  

}
