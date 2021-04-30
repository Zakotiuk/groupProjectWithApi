import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AddCourseDTo } from 'src/app/Models/addDTOs/AddCoursesDTO';
import { CoursService } from 'src/app/Services/cours.service';

@Component({
  selector: 'app-add-course',
  templateUrl: './add-course.component.html',
  styleUrls: ['./add-course.component.css']
})
export class AddCourseComponent implements OnInit {

  constructor(private service : CoursService) { }

  ngOnInit() {
  }
  model = new AddCourseDTo();
  onSubmit(form : NgForm){
    if(this.model.isValid()== true){
    this.service.addNew(this.model).subscribe(
        data=> {
          console.log(data);
          if(data.code === 200){
            // hide spinner !!!!!!!!!!!!!!!!!!!!!!!
            // this.notify i td..
          }else{
            //допиши тут помилки для нотіфаєра
          }
        }
      )
    }
  }

}
