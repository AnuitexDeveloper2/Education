import { Component, OnInit } from '@angular/core';
import { FormControl } from "@angular/forms";
import { AuthorService } from 'src/app/shared/services/author/author.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
  providers: [AuthorService]
})
export class CreateComponent implements OnInit {

  authorName = new FormControl('');

  constructor(private authorService:AuthorService) { }

  save(){
    debugger;
    this.authorService.save(this.authorName.value).subscribe();
  }

  ngOnInit() {
  }

}
