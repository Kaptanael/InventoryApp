import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';

import { WarehouseService } from '../../_services/warehouse.service';

@Component({
  selector: 'app-warehouse',
  templateUrl: './warehouse.component.html',
  styleUrl: './warehouse.component.css'
})
export class WarehouseComponent {
  public warehouses: any[] = [];
  public selectedWarehouseId: string | undefined;

  constructor(private warehouseService: WarehouseService,
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
    this.warehouseService.getAll().subscribe({
      next: (res) => {
        this.warehouses = res.body;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  onEdit(warehouse: any) {
    this.router.navigate(['./add-edit-warehouse', warehouse.id], { relativeTo: this.route });
  }

  onDelete(warehouse: any) {
    this.confirmationService.confirm({
      message: `Are you sure to delete this <b>${warehouse.name}</b>`,
      accept: () => {
        this.warehouseService.delete(warehouse.id)
          .subscribe({
            next: (res) => {
              if (res.status === 200) {
                this.getAll();
                this.messageService.add({ key: 'toastKey1', severity: 'success', summary: `Warehouse ${warehouse.name} has been deleted.`, detail: '' });
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
