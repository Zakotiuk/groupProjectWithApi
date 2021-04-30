import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AppRoutingModule } from './app-rouitng.module';
import { LoginComponent } from './Auth/Login/Login.component';
import { RegisterComponent } from './Auth/Register/Register.component';
import { NotifierModule } from 'angular-notifier';
import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TokenInterceptor } from './Services/interseptor';
import { AdminPanelComponent } from './Components/admin-panel/admin-panel/admin-panel.component';
import { TeacherProfileComponent } from './Components/teacher-profile/teacher-profile.component';
import { StudentProfileComponent } from './Components/user-profile/user-profile.component';
import { CoursesComponent } from './Components/courses/courses.component';
import { GroupComponent } from './Components/group/group.component';
import { TeacherComponent } from './Components/teacher/teacher.component';
import { StudentComponent } from './Components/student/student.component';
import { NewsComponent } from './Components/news/news.component';
import { AddNewsComponent } from './Components/add-new/addNews.component';
import { AddGroupComponent } from './Components/add-group/add-group.component';
import { AddCourseComponent } from './Components/add-course/add-course.component';
import { AddStudentComponent } from './Components/add-student/add-student.component';
import { AddTeacherComponent } from './Components/add-teacher/add-teacher.component';
import { LeftMenuComponent } from './Components/leftMenu/leftMenu.component';


@NgModule({
  declarations: [			
    AppComponent,
    NavMenuComponent,
    HomeComponent,
      LoginComponent,
      RegisterComponent,
      AdminPanelComponent,
      TeacherProfileComponent,
      StudentProfileComponent,
      CoursesComponent,
      GroupComponent,
      TeacherComponent,
      StudentComponent,
      NewsComponent,
      AddNewsComponent,
      AddGroupComponent,
      AddCourseComponent,
      AddStudentComponent,
      AddTeacherComponent,
      LeftMenuComponent
   ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    NgxSpinnerModule,
    BrowserAnimationsModule,
    FormsModule,
    AppRoutingModule,
    NotifierModule.withConfig({
      position: {
        horizontal: {
          position: 'right',
        },
        vertical: {
          position: 'top',
        }
      }
    })
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },NgxSpinnerService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
