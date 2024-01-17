import { HttpBackend, HttpClient, HttpHeaders, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthService } from "../common/service/auth.service";

@Injectable()
export class LoginService {
  private httpClient: HttpClient;
  public redirectUrl = "";

  constructor(private authService: AuthService, private httpBackend: HttpBackend) {
    this.httpClient = new HttpClient(httpBackend);
  }

  get isLoggedIn() {
    if (this.authService.isLoggedIn) {
      return true;
    }
    return false;
  }

  login(userId: string, password: string): Observable<HttpResponse<any>> {
    return this.authService.getToken(this.httpClient, userId, password);
  }
}
