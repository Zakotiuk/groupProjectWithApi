import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AddStudentDTo } from 'src/app/Models/addDTOs/AddStudents';
import { AddTeacherDTo } from 'src/app/Models/addDTOs/AddTeachers';
import { StudentService } from 'src/app/Services/student.service';
import { TeacherService } from 'src/app/Services/teacher.service';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']
})
export class AddStudentComponent implements OnInit {

  
  constructor(private service : StudentService) { }

  ngOnInit() {
  }
  model = new AddStudentDTo();
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