import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Login } from './login';
import { Register } from './register';
import { Observable } from 'rxjs';

import { JwtAuth } from './jwtAuth';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  registerUrl="http://localhost:5286/api/AuthManagement/Register";
  loginUrl="http://localhost:5286/api/AuthManagement/Login";
  wilayaUrl="http://localhost:5286/api/WilayaDate";

  constructor(private http:HttpClient) { }
//the request from the frontend --> background state( wait for response OBSERVABLE) -->backend
//when the response come back it pursuit 
  public register (user:Register): Observable<JwtAuth>{
    return this.http.post<JwtAuth>(`${this.registerUrl}`,user);
  }

  public login (user:Login): Observable<JwtAuth>{
    return this.http.post<JwtAuth>(`${this.loginUrl}`,user);
  }
  public getWilaya (): Observable<any>{
    return this.http.get<any>(`${this.wilayaUrl}`);


  }
  logout(): void {
    localStorage.removeItem('jwtToken');
  }
}
