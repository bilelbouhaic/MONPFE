// data-cube.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataCubeService {

  private apiUrl = 'https://api.coingecko.com/api/v3/simple/price?ids=ripple,cardano,dogecoin,chainlink&vs_currencies=usd';

  constructor(private http: HttpClient) { }

  getData(): Observable<any> {
    return this.http.get(this.apiUrl);
  }
}
