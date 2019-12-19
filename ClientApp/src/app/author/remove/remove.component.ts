import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { AuthorService } from 'src/app/shared/services/author/author.service';

@Component({
  selector: 'app-remove',
  templateUrl: './remove.component.html',
  styleUrls: ['./remove.component.css'],
  providers: [AuthorService]
})
export class RemoveComponent  {

  constructor(@Inject(MAT_DIALOG_DATA) public data: number, private authorService: AuthorService ) { }

 remove(){

  this.authorService.remove(this.data).subscribe();
 }

}
