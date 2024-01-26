import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';

import { RoleService } from '../../_services/role.service';

@Component({
  selector: 'app-role',  
  templateUrl: './role.component.html',
  styleUrl: './role.component.css'
})
export class RoleComponent implements OnInit {

  public roles: any[] = [];
  public selectedRoleId: string | undefined;
  public selectedRole: object | undefined;

  constructor(private roleService: RoleService,
    private router: Router,
    private route: ActivatedRoute,
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) {
  }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.roleService.getAll().subscribe({
      next: (res) => {
        console.log(res);
        this.roles = res.body;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  onEdit(role: any) {
    this.router.navigate(['./add-edit-role', role.id], { relativeTo: this.route });
  }

  onDelete(role: any) {
    this.confirmationService.confirm({
      message: `Are you sure to delete this <b>${role.name}</b>`,
      accept: () => {
        this.roleService.delete(role.id)
          .subscribe({
            next: (res) => {
              if (res.status === 200) {
                this.getAll();
                this.messageService.add({ key: 'toastKey1', severity: 'success', summary: `Role ${role.name} has been deleted.`, detail: '' });
              }
            },
            error: (err) => {
              this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Failed to delete role.', detail: '' });
            }
          });
      }
    });
  }
}

