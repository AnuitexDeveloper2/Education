import { Component, OnInit,Inject } from '@angular/core';
import { FormControl } from "@angular/forms";
import { MAT_DIALOG_DATA } from '@angular/material';
import { AuthorService } from 'src/app/shared/services/author/author.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
  providers: [AuthorService]
})
export class CreateComponent  {

  authorName = new FormControl('');

  constructor(@Inject(MAT_DIALOG_DATA) public data: string, private authorService:AuthorService) { }

  save(){
    debugger;
    this.authorService.save(this.authorName.value).subscribe();
  }

 
}
