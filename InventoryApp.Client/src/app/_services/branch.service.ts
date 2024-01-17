import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { resourceServerUrl } from '../common/auth-key';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BranchService {

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<HttpResponse<any>> {
    return this.http.get(`${resourceServerUrl}/api/v1/branch/getAll`, { observe: 'response' });
  }

}
