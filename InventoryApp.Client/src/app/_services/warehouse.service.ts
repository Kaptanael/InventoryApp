import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { resourceServerUrl } from '../common/auth-key';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WarehouseService {

  constructor(private httpClient: HttpClient) {
  }

  getAll(): Observable<HttpResponse<any>> {
    return this.httpClient.get(`${resourceServerUrl}/api/v1/warehouse/getAll`, { observe: 'response' });
  }

  getById(id: string): Observable<HttpResponse<any>> {
    return this.httpClient.get(`${resourceServerUrl}/api/v1/warehouse/getById/${id}`, { observe: 'response' });
  }

  create(model: any): Observable<HttpResponse<any>> {
    return this.httpClient.post(`${resourceServerUrl}/api/v1/warehouse/create`, model, {
      headers: new HttpHeaders()
        .set('Content-Type', 'application/json'), observe: 'response', responseType: 'text'
    });
  }

  update(id: string, model: any): Observable<HttpResponse<any>> {
    return this.httpClient.put(`${resourceServerUrl}/api/v1/warehouse/update/${id}`, model, {
      headers: new HttpHeaders()
        .set('Content-Type', 'application/json'), observe: 'response', responseType: 'text'
    });
  }

  delete(id: string): Observable<HttpResponse<any>> {
    return this.httpClient.delete(`${resourceServerUrl}/api/v1/warehouse/delete/${id}`, {
      headers: new HttpHeaders()
        .set('Content-Type', 'application/json'), observe: 'response', responseType: 'text'
    });
  }

}
