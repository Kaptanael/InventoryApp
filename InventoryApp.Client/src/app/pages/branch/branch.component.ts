import { Component, OnInit } from '@angular/core';
import { BranchService } from '../../_services/branch.service';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-branch',
  templateUrl: './branch.component.html',
  styleUrl: './branch.component.css'
})
export class BranchComponent implements OnInit {

  public branches: any[] = [];
  public selectedBranchId: string | undefined;

  constructor(private branchService: BranchService,
    private activeRoute: ActivatedRoute,
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) {
  }

  ngOnInit(): void {
    this.getBranchId();
    this.getAll();
  }

  getBranchId() {
    this.activeRoute.paramMap.subscribe(params => {
      console.log(params);
      if (params.get('id')) {
        this.selectedBranchId = params.get('id')?.toString();
        console.log(this.selectedBranchId);
      }
    });
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
