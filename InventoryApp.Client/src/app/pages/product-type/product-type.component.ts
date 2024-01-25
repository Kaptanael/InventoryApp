import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';

import { ProductTypeService } from '../../_services/product-type.service';

@Component({
  selector: 'app-product-type',  
  templateUrl: './product-type.component.html',
  styleUrl: './product-type.component.css'
})
export class ProductTypeComponent implements OnInit {

  public productTypes: any[] = [];
  public selectedProductTypeId: string | undefined;
  public selectedProductType: object | undefined;

  constructor(private productTypeService: ProductTypeService,
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
    this.productTypeService.getAll().subscribe({
      next: (res) => {
        console.log(res);
        this.productTypes = res.body;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  onEdit(productType: any) {
    this.router.navigate(['./add-edit-product-type', productType.id], { relativeTo: this.route });
  }

  onDelete(productType: any) {
    this.confirmationService.confirm({
      message: `Are you sure to delete this <b>${productType.name}</b>`,
      accept: () => {
        this.productTypeService.delete(productType.id)
          .subscribe({
            next: (res) => {
              if (res.status === 200) {
                this.getAll();
                this.messageService.add({ key: 'toastKey1', severity: 'success', summary: `Product type ${productType.name} has been deleted.`, detail: '' });
              }
            },
            error: (err) => {
              this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Failed to delete product type.', detail: '' });
            }
          });
      }
    });
  }
}

