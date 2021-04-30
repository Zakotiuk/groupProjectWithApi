import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddGroupDTo } from '../Models/addDTOs/AddGroupsDTO';
import { ApiCollectionResponse } from '../Models/api.response';

@Injectable({
  providedIn: 'root'
})
export class GroupService {

constructor(private http: HttpClient) { }
addNew(model : AddGroupDTo): Observable<ApiCollectionResponse>{
  return this.http.post<ApiCollectionResponse>(`/api/Admin/addGroups`, model);
}
delete(id: number) {
  return this.http.get<ApiCollectionResponse>(`/api/Admin/deleteGroups/${id}`);
}
getCourses(line: string): Observable<ApiCollectionResponse> {
  return this.http.get<ApiCollectionResponse>(`/api/Admin/${line}`);
}
getGroupForTeacher(id : string){
  return this.http.get(`/api/Admin/${id}`)
}
}
