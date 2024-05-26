import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BilanService {
  private apiUrl = 'http://localhost:5286/api/bilan/GenerateBilanPDF'; // Update this with your API URL

  constructor(private http: HttpClient) { }

  generateBilanPDF(): Observable<Blob> {
    return this.http.get(this.apiUrl, {
      responseType: 'blob' // Set the response type to blob
    });
  }
}
