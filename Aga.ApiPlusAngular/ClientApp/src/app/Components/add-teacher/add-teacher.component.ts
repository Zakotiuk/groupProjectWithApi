import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AddTeacherDTo } from 'src/app/Models/addDTOs/AddTeachers';
import { TeacherService } from 'src/app/Services/teacher.service';

@Component({
  selector: 'app-add-teacher',
  templateUrl: './add-teacher.component.html',
  styleUrls: ['./add-teacher.component.css']
})
export class AddTeacherComponent implements OnInit {

  constructor(private service : TeacherService) { }

  ngOnInit() {
  }
  model = new AddTeacherDTo();
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
