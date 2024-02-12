import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { resourceServerUrl } from '../common/auth-key';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<HttpResponse<any>> {
    return this.httpClient.get(`${resourceServerUrl}/api/v1/user/getAll`, { observe: 'response' });
  }

  getById(id: string): Observable<HttpResponse<any>> {
    return this.httpClient.get(`${resourceServerUrl}/api/v1/user/getById/${id}`, { observe: 'response' });
  }

  create(model: any): Observable<HttpResponse<any>> {
    return this.httpClient.post(`${resourceServerUrl}/api/v1/user/create`, model, {
      headers: new HttpHeaders()
        .set('Content-Type', 'application/json'), observe: 'response', responseType: 'text'
    });
  }

  update(id: string, model: any): Observable<HttpResponse<any>> {
    return this.httpClient.put(`${resourceServerUrl}/api/v1/user/update/${id}`, model, {
      headers: new HttpHeaders()
        .set('Content-Type', 'application/json'), observe: 'response', responseType: 'text'
    });
  }

  delete(id: string): Observable<HttpResponse<any>> {
    return this.httpClient.delete(`${resourceServerUrl}/api/v1/user/delete/${id}`, {
      headers: new HttpHeaders()
        .set('Content-Type', 'application/json'), observe: 'response', responseType: 'text'
    });
  }
}
