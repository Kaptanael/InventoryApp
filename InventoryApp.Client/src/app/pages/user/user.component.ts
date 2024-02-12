import { Component, ViewChild } from '@angular/core';
import { UserRoleService } from '../../_services/user-role.service';
import { UserService } from '../../_services/user.service';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Table } from 'primeng/table'
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent {

  public userLists: [] = [];

  @ViewChild('userTableRef') dt: Table | undefined;

  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute,
    private messageService: MessageService, private confirmationService: ConfirmationService) {
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
    this.router.navigate(['./add-edit-user', id], { relativeTo: this.route });
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt?.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }

  onDelete(user: any) {
    this.confirmationService.confirm({
      message: `Are you sure you want to delete <b>${user.firstName} ${user.lastName} User</b>`,
      accept: () => {
        this.userService.delete(user.id)
          .subscribe(response => {
            if (response.status === 200) {
              //this.isLoading = false;
              this.messageService.add({ key: 'toastKey1', severity: 'success', summary: `${user.firstName} ${user.lastName} User has been deleted.`, detail: '' });
              this.getAll();
            }
          },
            err => {
              //this.isLoading = false;
              this.messageService.add({ key: 'toastKey1', severity: 'error', summary: err.error.ExceptionMessage, detail: '' });
            },
            () => {
              //this.isLoading = false;
            });
      }
    });
  }

}
