// data-cube.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WilayaQTeService {

  private apiUrl1 = 'http://localhost:5286/api/WilayaData/1';
  private apiUrl3= 'http://localhost:5286/api/WilayaData/3';
  private apiUrl33 = 'http://localhost:5286/api/WilayaData/33';

  constructor(private http: HttpClient) { }

  getData1(): Observable<any> {
    return this.http.get(this.apiUrl1);
  }
  getData3(): Observable<any> {
    return this.http.get(this.apiUrl3);
  }
  getData33(): Observable<any> {
    return this.http.get(this.apiUrl33);
  }
}
