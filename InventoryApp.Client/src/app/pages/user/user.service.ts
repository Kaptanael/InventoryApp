import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { resourceServerUrl } from '../../common/auth-key';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<HttpResponse<any>> {
    return this.httpClient.get(`${resourceServerUrl}/api/v1/user/getAll`, { observe: 'response' });
  }
}
