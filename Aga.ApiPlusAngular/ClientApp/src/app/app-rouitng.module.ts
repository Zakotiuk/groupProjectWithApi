import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';
import { LoginComponent } from './Auth/Login/Login.component';
import { RegisterComponent } from './Auth/Register/Register.component';
import { AdminGuard } from './Guards/admin.guard';
import { NotLoggedInGuard } from './Guards/isNotLogin.guard';
import { StudentGuard } from './Guards/user.quard';
import { HomeComponent } from './home/home.component';
import { StudentProfileComponent} from './Components/user-profile/user-profile.component';
import { TeacherProfileComponent } from './Components/teacher-profile/teacher-profile.component';
import { AdminPanelComponent } from './Components/admin-panel/admin-panel/admin-panel.component';
import { CoursesComponent } from './Components/courses/courses.component';
import { GroupComponent } from './Components/group/group.component';
import { TeacherComponent } from './Components/teacher/teacher.component';
import { StudentComponent } from './Components/student/student.component';
import { NewsComponent } from './Components/news/news.component';
import { AddNewsComponent } from './Components/add-new/addNews.component';
import { AddCourseComponent } from './Components/add-course/add-course.component';
import { AddStudentComponent } from './Components/add-student/add-student.component';
import { AddTeacherComponent } from './Components/add-teacher/add-teacher.component';

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'login', pathMatch: 'full', canActivate:[NotLoggedInGuard] ,component: LoginComponent },
    { path: 'register', pathMatch: 'full', canActivate:[NotLoggedInGuard], component: RegisterComponent },
    { path: 'admin-panel', canActivate:[AdminGuard], component: AdminPanelComponent,
    children:[
        {
            path:'courses', component: CoursesComponent, pathMatch: 'full',
        },
        {
            path:'groups', component: GroupComponent, pathMatch: 'full'
        },
        {
            path:'teachers', component: TeacherComponent, pathMatch: 'full'
        },
        {
            path:'students', component: StudentComponent, pathMatch: 'full'
        },
        {
            path:'news', component: NewsComponent, pathMatch: 'full'
        },
        {
            path:'addNew', component: AddNewsComponent, pathMatch: 'full'
        },
        {
            path:'addCours', component: AddCourseComponent, pathMatch: 'full'
        },
        {
            path:'addStudent', component: AddStudentComponent, pathMatch: 'full'
        },
        {
            path:'addTeacher', component: AddTeacherComponent, pathMatch: 'full'
        }
    ]},
    { path: 'student-profile', pathMatch: 'full', canActivate:[StudentGuard], component: StudentProfileComponent},
    { path: 'teacher-profile', pathMatch: 'full', canActivate:[StudentGuard], component: TeacherProfileComponent },


];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }