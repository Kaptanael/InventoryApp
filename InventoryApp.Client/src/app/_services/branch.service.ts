import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { resourceServerUrl } from '../common/auth-key';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BranchService {

  constructor(private httpClient: HttpClient) {
  }

  getAll(): Observable<HttpResponse<any>> {
    return this.httpClient.get(`${resourceServerUrl}/api/v1/branch/getAll`, { observe: 'response' });
  }

  getById(id: string): Observable<HttpResponse<any>> {
    return this.httpClient.get(`${resourceServerUrl}/api/v1/branch/getById/${id}`, { observe: 'response' });
  }

  save(model: any): Observable<HttpResponse<any>> {
    return this.httpClient.post(`${resourceServerUrl}/api/v1/branch/create`, model, {
      headers: new HttpHeaders()
        .set('Content-Type', 'application/json'), observe: 'response', responseType: 'text'
    });
  }

}
