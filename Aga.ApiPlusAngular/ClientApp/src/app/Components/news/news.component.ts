import { Component, OnInit } from '@angular/core';
import { ApiCollectionResponse } from 'src/app/Models/api.response';
import { NewDTo } from 'src/app/Models/mainDTOs/newsDTO';
import { GetService } from 'src/app/Services/gets.service';
import { NewsService } from 'src/app/Services/news.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {

  constructor(private newsService : NewsService) { }
  news!: Array<NewDTo>;

  ngOnInit() {
    this.initComponet();
   }

   initComponet(){
    this.newsService.getCourses("news").subscribe((res: ApiCollectionResponse)=>{
      if(res.code == 200){
        this.news = res.data;
        console.log(this.news);
      }
    })}
    deleteComponent(id : number){
      this.newsService.delete(id).subscribe((res: ApiCollectionResponse)=>{
          this.initComponet();
      })
    }
  }
