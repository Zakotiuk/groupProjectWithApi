import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AddGroupDTo } from 'src/app/Models/addDTOs/AddGroupsDTO';
import { GroupService } from 'src/app/Services/group.service';

@Component({
  selector: 'app-add-group',
  templateUrl: './add-group.component.html',
  styleUrls: ['./add-group.component.css']
})
export class AddGroupComponent implements OnInit {

  constructor(private service : GroupService) { }

  ngOnInit() {
  }
  model = new AddGroupDTo();
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
