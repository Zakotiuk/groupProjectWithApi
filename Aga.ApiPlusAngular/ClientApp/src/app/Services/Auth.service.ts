import { HttpClient } from '@angular/common/http';
import { Injectable, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';
import { Apiresponse } from '../Models/api.response';
import { LoginModel } from '../Models/login.model';
import { RegisterModel } from '../Models/register.model';
import jwt_decode from "jwt-decode"

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }
  baseUrl = "/api/Account";
  loginStatus = new EventEmitter<boolean>();
  token_data: any;
  register(model: RegisterModel): Observable<Apiresponse> {
    return this.http.post<Apiresponse>(this.baseUrl + "/register", model)
  }

  login(model: LoginModel): Observable<Apiresponse> {
    return this.http.post<Apiresponse>(this.baseUrl + "/login", model)
  }

  isAdmin(): boolean {
    var current_token = localStorage.getItem('token');
    if (current_token != null) {
      this.token_data = jwt_decode(current_token);
      if (this.token_data.roles == "Admin") {
        return true;
      } else {
        return false;
      }
    }
    else {
      return false;
    }
  }

  isStudent(): boolean {
    var current_token = localStorage.getItem('token');
    if (current_token != null) {
      this.token_data = jwt_decode(current_token);
      if (this.token_data.roles == "Student") {
        return true;
      } else {
        return false;
      }
    }
    else {
      return false;
    }
  }

  isTeacher(): boolean {
    var current_token = localStorage.getItem('token');
    if (current_token != null) {
      this.token_data = jwt_decode(current_token);
      if (this.token_data.roles == "Teacher") {
        return true;
      } else {
        return false;
      }
    }
    else {
      return false;
    }
  }



  isLoggetIn(): boolean {
    var current_token = localStorage.getItem('token');
    if (current_token != null) {
      return true;
    } else {
      return false;
    }
  }

  Logout(){
    this.loginStatus.emit(false);
    localStorage.removeItem('token');
  }

}

