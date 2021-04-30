import { Injectable } from '@angular/core';
import { ApiCollectionResponse } from '../Models/api.response';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {AddNewDTO} from 'src/app/Models/addDTOs/AddNewsDTO'

@Injectable({
  providedIn: 'root'
})
export class NewsService {

constructor(private http: HttpClient) { }
addNew(model : AddNewDTO): Observable<ApiCollectionResponse>{
  return this.http.post<ApiCollectionResponse>(`/api/Admin/addNews`, model);
}
delete(id: number) {
  return this.http.get<ApiCollectionResponse>(`/api/Admin/deleteNews/${id}`);
}
getCourses(line: string): Observable<ApiCollectionResponse> {
  return this.http.get<ApiCollectionResponse>(`/api/Admin/${line}`);
}}
