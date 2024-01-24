import { Component } from '@angular/core';
import { UserRoleService } from '../user-role/user-role.service';
import { UserService } from './user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent {
  public userLists: [] = [];
  constructor(private userService: UserService) {
  }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.userService.getAll().subscribe({
      next: (res) => {
        this.userLists = res.body;
        console.log(res);
      },
      error: (err) => {
        console.log(err);
      }

    })
  }
}
