import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiCollectionResponse } from '../Models/api.response';

@Injectable({
  providedIn: 'root'
})
export class GetService {

  constructor(private http: HttpClient) { }

  getCourses(line : string): Observable<ApiCollectionResponse> {
    return this.http.get<ApiCollectionResponse>(`/api/Admin/${line}`);
    
    
  
}

}
