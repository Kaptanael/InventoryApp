import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from './login.service';
import { authCookieKey } from '../common/auth-key';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})

export class LoginComponent {

  public loginId: string = "";
  public password: string = "";
  constructor(private router: Router, private loginService: LoginService) {
  }

  onLogin() {
    this.loginService.login(this.loginId, this.password).subscribe({
      next: (res) => {
        localStorage.setItem(authCookieKey, JSON.stringify(res))
        this.router.navigateByUrl("/");
      },
      error: (err) => {
        console.log(err);
      },
      complete: () => {
        if (this.loginService.redirectUrl) {
          this.router.navigateByUrl(this.loginService.redirectUrl);
          this.loginService.redirectUrl = "";
        }
        else {
          this.router.navigate(['/']);
        }
      }
    });
    this.router.navigate(['/']);
  }

}
