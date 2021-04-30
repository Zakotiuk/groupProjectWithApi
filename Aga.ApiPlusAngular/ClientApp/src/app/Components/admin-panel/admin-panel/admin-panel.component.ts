import { Component, OnInit } from '@angular/core';
import { ApiCollectionResponse } from 'src/app/Models/api.response';
import { CourseDTo } from 'src/app/Models/mainDTOs/coursDTO';
import { GetService } from 'src/app/Services/gets.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css'],
})
export class AdminPanelComponent implements OnInit {

  constructor(private getSetvice : GetService) { }

  courses!: Array<CourseDTo>;

  ngOnInit() {
  }

  nowPosition;
  changePosition(id){
    this.nowPosition = id;
    return id;
  }
 
    
}
