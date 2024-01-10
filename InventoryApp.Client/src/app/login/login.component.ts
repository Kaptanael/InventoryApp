import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})

export class LoginComponent {
  public loginId: string = "";
  public password: string = "";
  constructor(private router: Router) {
  }

  onLogin() {
    this.router.navigate(['/']);
  }

}
