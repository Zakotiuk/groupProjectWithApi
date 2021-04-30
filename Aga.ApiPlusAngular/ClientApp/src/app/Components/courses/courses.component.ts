import { Component, OnInit } from '@angular/core';
import { ApiCollectionResponse } from 'src/app/Models/api.response';
import { CourseDTo } from 'src/app/Models/mainDTOs/coursDTO';
import { CoursService } from 'src/app/Services/cours.service';
import { GetService } from 'src/app/Services/gets.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {

  constructor(private courseService : CoursService) { }
  courses!: Array<CourseDTo>;
  

  

  ngOnInit() {
    this.initComponet();
   }
   initComponet(){
    this.courseService.getCourses("course").subscribe((res: ApiCollectionResponse)=>{
      if(res.code == 200){
        this.courses = res.data;
        console.log(this.courses);
      }
    })}
    deleteComponent(id : number){
      this.courseService.delete(id).subscribe((res: ApiCollectionResponse)=>{
        this.initComponet();
      })
    }
  }
