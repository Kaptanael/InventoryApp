import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';

import { BranchService } from '../../_services/branch.service';

@Component({
  selector: 'app-branch',
  templateUrl: './branch.component.html',
  styleUrl: './branch.component.css'
})
export class BranchComponent implements OnInit {

  public branches: any[] = [];
  public selectedBranchId: string | undefined;
  public search: string = '';

  constructor(private branchService: BranchService,
    private router: Router,
    private route: ActivatedRoute,
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) {
  }

  ngOnInit(): void {
    this.getAll(this.search);
  }

  getAll(search: string) {
    this.branchService.getAll(search).subscribe({
      next: (res) => {
        this.branches = res.body;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  onSearch() {
    this.getAll(this.search);
  }

  onEdit(branch: any) {
    this.router.navigate(['./add-edit-branch', branch.id], { relativeTo: this.route });
  }

  onDelete(branch: any) {
    this.confirmationService.confirm({
      message: `Are you sure to delete this <b>${branch.name}</b>`,
      accept: () => {
        this.branchService.delete(branch.id)
          .subscribe({
            next: (res) => {
              if (res.status === 200) {
                this.getAll(this.search);
                this.messageService.add({ key: 'toastKey1', severity: 'success', summary: `Branch ${branch.name} has been deleted.`, detail: '' });
              }
            },
            error: (err) => {
              this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Failed to delete branch.', detail: '' });
            }
          });
      }
    });
  }
}

