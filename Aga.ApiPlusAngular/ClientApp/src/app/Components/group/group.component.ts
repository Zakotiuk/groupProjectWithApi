import { Component, OnInit } from '@angular/core';
import { ApiCollectionResponse } from 'src/app/Models/api.response';
import { GroupDTo } from 'src/app/Models/mainDTOs/groupsDTO';
import { GetService } from 'src/app/Services/gets.service';
import { GroupService } from 'src/app/Services/group.service';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.css']
})
export class GroupComponent implements OnInit {

  constructor(private groupService : GroupService) { }
  groups!: Array<GroupDTo>;

  ngOnInit() {
    this.initComponet();
   }
   initComponet(){
    this.groupService.getCourses("group").subscribe((res: ApiCollectionResponse)=>{
      if(res.code == 200){
        this.groups = res.data;
        console.log(this.groups);
      }
    })}
    deleteComponent(id : number){
      this.groupService.delete(id).subscribe((res: ApiCollectionResponse)=>{
        console.log(res);
      })
    }
  }
