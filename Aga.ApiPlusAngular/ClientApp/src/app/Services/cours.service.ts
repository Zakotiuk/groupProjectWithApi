import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddCourseDTo } from '../Models/addDTOs/AddCoursesDTO';
import { ApiCollectionResponse } from '../Models/api.response';

@Injectable({
  providedIn: 'root'
})
export class CoursService {

  constructor(private http: HttpClient) { }
  addNew(model: AddCourseDTo): Observable<ApiCollectionResponse> {
    return this.http.post<ApiCollectionResponse>(`/api/Admin/addCourses`, model);
  }
  delete(id: number) {
    return this.http.get<ApiCollectionResponse>(`/api/Admin/deleteCourses/${id}`);
  }
  getCourses(line: string): Observable<ApiCollectionResponse> {
    return this.http.get<ApiCollectionResponse>(`/api/Admin/${line}`);
  }
}