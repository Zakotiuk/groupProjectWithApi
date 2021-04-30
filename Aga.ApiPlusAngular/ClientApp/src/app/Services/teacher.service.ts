import { Injectable } from '@angular/core';
import { ApiCollectionResponse } from '../Models/api.response';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddTeacherDTo } from '../Models/addDTOs/AddTeachers';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {


  constructor(private http: HttpClient) { }
  addNew(model: AddTeacherDTo): Observable<ApiCollectionResponse> {
    return this.http.post<ApiCollectionResponse>(`/api/Admin/addTeachers`, model);
  } 
  delete(id: number) {
    return this.http.get<ApiCollectionResponse>(`/api/Admin/deleteTeachers/${id}`);
  }
  getCourses(line: string): Observable<ApiCollectionResponse> {
    return this.http.get<ApiCollectionResponse>(`/api/Admin/${line}`);
  }
}
