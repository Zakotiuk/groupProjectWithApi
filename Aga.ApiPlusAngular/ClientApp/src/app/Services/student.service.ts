import { Injectable } from '@angular/core';
import { ApiCollectionResponse } from '../Models/api.response';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddStudentDTo } from '../Models/addDTOs/AddStudents';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private http: HttpClient) { }
  addNew(model : AddStudentDTo): Observable<ApiCollectionResponse>{
    return this.http.post<ApiCollectionResponse>(`/api/Admin/addStudents`, model);
  }
  delete(id: number) {
    return this.http.get<ApiCollectionResponse>(`/api/Admin/deleteStundets/${id}`);
  }
  getCourses(line: string): Observable<ApiCollectionResponse> {
    return this.http.get<ApiCollectionResponse>(`/api/Admin/${line}`);
  }}
  
