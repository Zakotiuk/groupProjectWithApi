import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../Services/Auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  isLoggetIn: boolean;
  isAdmin: boolean;
  isTeacher: boolean;
  isStudent : boolean;
  constructor(private authService: AuthService,
    private router: Router) {
    this.isLoggetIn = this.authService.isLoggetIn();
    this.isAdmin = this.authService.isAdmin();
    this.isTeacher = this.authService.isTeacher();
    this.isStudent = this.authService.isStudent();


    this.authService.loginStatus.subscribe((status)=>{
      this.isLoggetIn = status;
      this.isAdmin = this.authService.isAdmin();
    })
  }

  Logout() {
    this.authService.Logout();
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
