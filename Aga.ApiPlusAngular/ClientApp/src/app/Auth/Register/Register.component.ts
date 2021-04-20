import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotifierService } from 'angular-notifier';
import { from } from 'rxjs';
import { RegisterModel } from 'src/app/Models/register.model';
import { AuthService } from 'src/app/Services/Auth.service';

@Component({
  selector: 'app-Register',
  templateUrl: './Register.component.html',
  styleUrls: ['./Register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private notifier: NotifierService,
    private router: Router,
    private auth: AuthService) { }
  confirmPassword: string;


  model = new RegisterModel();


  submitRegister() {
    if (!this.model.isValid()) {
      this.notifier.notify("error", "Please, enter all fields")
    }
    else if (this.confirmPassword != this.model.Password) {
      this.notifier.notify("error", "Password dont match!")
    } 
    else if (!this.model.isEmail()) {
      this.notifier.notify("error", "Right email pelease!")
    }
    else {
      this.auth.register(this.model).subscribe(data => {
        if (data.code == 200) {
          this.notifier.notify("success", "You success registered in system!");
          this.router.navigate(["/login"])
        }
        else {
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
