import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AddNewDTO } from 'src/app/Models/addDTOs/AddNewsDTO';
import { NewDTo } from 'src/app/Models/mainDTOs/newsDTO';
import { NewsService } from 'src/app/Services/news.service';

@Component({
  selector: 'app-addNews',
  templateUrl: './addNews.component.html',
  styleUrls: ['./addNews.component.css']
})
export class AddNewsComponent implements OnInit {

  constructor(private service : NewsService,
    private route : Router) {
   }

  ngOnInit() {
  }

  model = new AddNewDTO();

  onSubmit(form : NgForm){
    if(this.model.isValid()== true){
    this.service.addNew(this.model).subscribe(
        data=> {
          console.log(data);
          if(data.code === 200){
            // hide spinner !!!!!!!!!!!!!!!!!!!!!!!
            // this.notify i td..
            this.route.navigate(['/admin-panel/news']);
          }else{
            //допиши тут помилки для нотіфаєра
          }
        }
      )
    }
  }

}
