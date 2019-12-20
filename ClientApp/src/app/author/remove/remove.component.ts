import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { AuthorService } from 'src/app/shared/services/author/author.service';
import { AuthorModelItem } from 'src/app/shared/models/author/AuthorModelItem';

@Component({
  selector: 'app-remove',
  templateUrl: './remove.component.html',
  styleUrls: ['./remove.component.css'],
  providers: [AuthorService]
})
export class RemoveComponent  {

  constructor(@Inject(MAT_DIALOG_DATA) public data: AuthorModelItem, private authorService: AuthorService ) { }

 remove(){
  debugger;
  this.authorService.remove(this.data.id).subscribe();
 }

}
