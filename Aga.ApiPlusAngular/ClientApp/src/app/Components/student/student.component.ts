import { Component, OnInit } from '@angular/core';
import { ApiCollectionResponse } from 'src/app/Models/api.response';
import { StudentDTo } from 'src/app/Models/mainDTOs/studentsDTO';
import { GetService } from 'src/app/Services/gets.service';
import { StudentService } from 'src/app/Services/student.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

 
 
  constructor(private studentService : StudentService) { }
  students!: Array<StudentDTo>;

  ngOnInit() {
    this.initComponet();
   }
   initComponet(){
    this.studentService.getCourses("student").subscribe((res: ApiCollectionResponse)=>{
      if(res.code == 200){
        this.students = res.data;
        console.log(this.students);
      }
    })}
    deleteComponent(id : number){
      this.studentService.delete(id).subscribe((res: ApiCollectionResponse)=>{
        console.log(res);
      })
    }
  }
