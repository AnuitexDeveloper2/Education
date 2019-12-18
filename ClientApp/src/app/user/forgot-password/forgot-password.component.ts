import { Component, OnInit } from '@angular/core';
import { UserService } from "../../shared/services/user.service";
import { FormControl } from "@angular/forms";


@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css'],
  providers:[UserService]
})
export class ForgotPasswordComponent implements OnInit {

  constructor(private userService: UserService) { }
  
  email = new FormControl('');   

   forgot(){
   debugger;
   this.userService.forgotPassword(this.email.value).subscribe()
 }

  ngOnInit() {
  }

}
