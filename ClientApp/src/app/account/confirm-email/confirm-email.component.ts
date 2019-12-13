import { Component, OnInit } from '@angular/core';
import { AccountService } from "../../shared/services/account/account.service";

@Component({
  selector: 'app-confirm-email',
  templateUrl: './confirm-email.component.html',
  styleUrls: ['./confirm-email.component.css'],
  providers:[AccountService]
})
export class ConfirmEmailComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
