import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotifierService } from 'angular-notifier';
import { LoginModel } from 'src/app/Models/login.model';
import { AuthService } from 'src/app/Services/Auth.service';
import jwt_decode from "jwt-decode";
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-Login',
  templateUrl: './Login.component.html',
  styleUrls: ['./Login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private notifier: NotifierService,
    private router: Router,
    private auth: AuthService,
    private spinner: NgxSpinnerService) { }
  confirmPassword: string;
  token_data : any;

  model = new LoginModel();


  submitLogin() {
    this.spinner.show();
    if (!this.model.isValid()) {
      this.notifier.notify("error", "Please, enter all fields")
    }
    else if (!this.model.isEmail()) {
      this.notifier.notify("error", "Right email pelease!")
    }
    else {
      this.auth.login(this.model).subscribe(data => {
        if (data.code == 200) {
          this.notifier.notify("success", "You success registered in system!");
          localStorage.setItem("token", data.token);
          this.auth.loginStatus.emit(true);
           this.token_data = jwt_decode(data.token);


          if(this.token_data.roles == "Admin"){
            this.router.navigate(['/login-panel'])
          }
          else if(this.token_data.roles == "Student"){
            this.router.navigate(['/student-profile']);
          }
          else if(this.token_data.roles == "Teacher"){
            this.router.navigate(['/teacher-profile']);
          }
          this.spinner.hide();
        }
        else {
          this.spinner.hide();
          for (var i = 0; i < data.errors.lenght; ++i) {
            this.notifier.notify("error", data.errors[i]);
          }
        }
      })
    }
  }
  ngOnInit() {
  }

}