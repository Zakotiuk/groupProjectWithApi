import { Component, OnInit } from '@angular/core';
import { ApiCollectionResponse } from 'src/app/Models/api.response';
import { TeacherDTo } from 'src/app/Models/mainDTOs/teachersDTO';
import { GetService } from 'src/app/Services/gets.service';
import { TeacherService } from 'src/app/Services/teacher.service';

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.css']
})
export class TeacherComponent implements OnInit {

 
  constructor(private teacherService : TeacherService) { }
  teachers!: Array<TeacherDTo>;

  ngOnInit() {
    this.initComponet();
   }
   initComponet(){
    this.teacherService.getCourses("teachers").subscribe((res: ApiCollectionResponse)=>{
      if(res.code == 200){
        this.teachers = res.data;
        console.log(this.teachers);
      }
    })}
    deleteComponent(id : number){
      this.teacherService.delete(id).subscribe((res: ApiCollectionResponse)=>{
        console.log(res);
      })
    }
  }
