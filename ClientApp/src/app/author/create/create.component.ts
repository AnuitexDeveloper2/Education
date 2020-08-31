import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material';
import { FormControl } from '@angular/forms';
import { AuthorService } from 'src/app/shared/services/author/author.service';
import { AuthorModelItem } from 'src/app/shared/models/author/AuthorModelItem';
import { BaseModel } from 'src/app/shared/models/Base/BaseModel';
import { ErrorComponent } from 'src/app/shared/components/error/error.component';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
  providers: [AuthorService]
})
export class CreateComponent {

  authorModel: AuthorModelItem;
  authorName: FormControl;
  baseModel: BaseModel;
  constructor(@Inject(MAT_DIALOG_DATA) public data: AuthorModelItem, private authorService: AuthorService, private dialog: MatDialog) {
    this.authorModel = new AuthorModelItem();
    this.authorName = new FormControl(data.name);
    this.baseModel = new BaseModel();
  }

  save() {
    this.authorModel.name = this.authorName.value;
    if (this.data.id === 0) {
      this.authorService.save(this.authorModel).subscribe(data => {
        this.baseModel.errors = data.errors;
        this.checkError(this.baseModel.errors);
      });
    }

    if (this.data.id > 0) {
      this.authorService.edit(this.data.id, this.authorModel.name).subscribe(data => {
        this.baseModel.errors = data.errors;
        this.checkError(this.baseModel.errors);
      });
    }
  }

  private checkError(errors: Array<string>) {
    if (errors.length > 0) {
      this.dialog.open(ErrorComponent, { data: this.baseModel.errors })
    }
  }
}


