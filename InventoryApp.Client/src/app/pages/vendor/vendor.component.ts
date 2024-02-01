import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';
import { VendorService } from '../../_services/vendor.service';



@Component({
  selector: 'app-vendor',
  templateUrl: './vendor.component.html',
  styleUrl: './vendor.component.css'
})
export class VendorComponent implements OnInit {

  public vendors: any[] = [];
  public selectedVendorId: string | undefined;

  constructor(private vendorService: VendorService,
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
    this.vendorService.getAll().subscribe({
      next: (res) => {
        this.vendors = res.body;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  onEdit(vendor: any) {
    this.router.navigate(['./add-edit-vendor', vendor.id], { relativeTo: this.route });
  }

  onDelete(vendor: any) {
    this.confirmationService.confirm({
      message: `Are you sure to delete this <b>${vendor.name}</b>`,
      accept: () => {
        this.vendorService.delete(vendor.id)
          .subscribe({
            next: (res) => {
              if (res.status === 200) {
                this.getAll();
                this.messageService.add({ key: 'toastKey1', severity: 'success', summary: `Vendor ${vendor.name} has been deleted.`, detail: '' });
              }
            },
            error: (err) => {
              this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Failed to delete vendor.', detail: '' });
            }
          });
      }
    });
  }
}
    
