import { Component, OnInit, Inject } from '@angular/core';
import { UserService } from "../../shared/services/user.service";
import { MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css'],
  providers: [UserService]
})
export class EditProfileComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private userService: UserService) { }

  ngOnInit() {
  }

}
