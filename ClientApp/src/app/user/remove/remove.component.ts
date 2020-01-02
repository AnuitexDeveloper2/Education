import { Component, Inject } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { MAT_DIALOG_DATA } from '@angular/material';
import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';
import { AuthorModelItem } from 'src/app/shared/models/author/AuthorModelItem';
import { AuthorService } from 'src/app/shared/services/author/author.service';


@Component({
  selector: 'app-remove',
  templateUrl: './remove.component.html',
  styleUrls: ['./remove.component.css'],
  providers: [UserService]
})
export class RemoveComponent  {
    constructor(@Inject(MAT_DIALOG_DATA) public data: any, private userService: UserService, private authorService: AuthorService) { }

  remove(){
     debugger;
     if(this.data == UserModelItem)
     {
       this.userService.removeUser(this.data.id).subscribe();
     }
    if(this.data == AuthorModelItem)
    {
      this.authorService.remove(this.data.id).subscribe();
    }

  }

  

}
