import { Component, OnInit } from '@angular/core';
import { BranchService } from '../../_services/branch.service';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-branch',
  templateUrl: './branch.component.html',
  styleUrl: './branch.component.css'
})
export class BranchComponent implements OnInit {

  public branches: [] = [];

  constructor(private branchService: BranchService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) {
  }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.branchService.getAll().subscribe({
      next: (res) => {
        this.branches = res.body;
        console.log(res);
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  onEdit(branch: any) {

  }

  onDelete(branch: any) {
    this.confirmationService.confirm({
      message: `Are you sure to delete  <b>${branch.name}</b>`,
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
