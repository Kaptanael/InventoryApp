import { Component } from '@angular/core';
import { UserRoleService } from '../user-role/user-role.service';
import { UserService } from './user.service';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent {
  public userLists: [] = [];
  constructor(private userService: UserService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
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

  onEdit(id: number) {
    //this.router.navigate(['./add-edit-branch', branch.id], { relativeTo: this.route });
  }

  onDelete(user: any) {
    this.confirmationService.confirm({
      message: `Are you sure to delete  <b>${user.firstName}</b>`,
      accept: () => {
        //this.userManagementService.deleteUserById(loginId)
        //  .subscribe(response => {
        //    if (response.status === 200) {
        //      this.isLoading = false;
        //      this.messageService.add({ key: 'toastKey1', severity: 'success', summary: `User ${loginId} has been deleted.`, detail: '' });
        //      this.getUsers();
        //    }
        //  },
        //    err => {
        //      this.isLoading = false;
        //      this.messageService.add({ key: 'toastKey1', severity: 'error', summary: err.error.ExceptionMessage, detail: '' });
        //    },
        //    () => {
        //      this.isLoading = false;
        //    });
      }
    });
  }

}
