import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';

import { WarehouseService } from '../../../_services/warehouse.service';


@Component({
  selector: 'app-add-edit-warehouse',
  templateUrl: './add-edit-warehouse.component.html',
  styleUrls: ['./add-edit-warehouse.component.css']
})
export class AddEditWarehouseComponent implements OnInit {

  public formGroup!: FormGroup;
  public selectedWarehouse: any = null;
  public selectedWarehouseId: string | undefined;
  public title: string | undefined;

  constructor(private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private messageService: MessageService,
    private warehouseService: WarehouseService) {
    this.createFormGroup();
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => params.get('id') ? this.selectedWarehouseId = params.get('id')?.toString() : null);
    this.title = this.selectedWarehouseId ? 'Edit Warehouse' : 'Add Warehouse';
    this.getById();
  }

  createFormGroup(): void {
    this.formGroup = this.fb.group({
      name: ['', [this.noWhitespaceValidator, Validators.required, Validators.maxLength(50)]],
      status: ['1', Validators.required],
      description: ['', [this.noWhitespaceValidator, Validators.maxLength(200)]],
      street: ['', [this.noWhitespaceValidator, Validators.required, Validators.maxLength(200)]],
      city: ['', [this.noWhitespaceValidator, Validators.required, Validators.maxLength(50)]],
      province: ['', [this.noWhitespaceValidator, Validators.required, Validators.maxLength(50)]],
      country: ['', [this.noWhitespaceValidator, Validators.required, Validators.maxLength(50)]]
    });
  }

  getById(): void {
    if (this.selectedWarehouseId) {
      this.warehouseService.getById(this.selectedWarehouseId).subscribe({
        next: (res) => {
          this.selectedWarehouse = res.body;
          this.fillUpFields();
        },
        error: (err) => {
          console.log(err);
        }
      });
    }
  }

  fillUpFields(): void {
    if (this.selectedWarehouse) {
      this.formGroup.patchValue({
        name: this.selectedWarehouse.name,
        status: this.getStringBoolean(this.selectedWarehouse.status),
        description: this.selectedWarehouse.description,
        street: this.selectedWarehouse.streetAddress,
        city: this.selectedWarehouse.city,
        province: this.selectedWarehouse.province,
        country: this.selectedWarehouse.country,
      })
    }
  }

  noWhitespaceValidator(control: AbstractControl) {
    if (control && control.value && !control.value.replace(/\s/g, '').length) {
      control.setValue('');
    }
    return null;
  }

  getStringBoolean(value: boolean): string {
    if (value == true) {
      return "1";
    }
    return "0";
  }

  onClear(): void {
    this.formGroup.reset();
    this.formGroup.patchValue({ status: 1 });
  }

  onSubmit(): void {

    const model = {
      id: this.selectedWarehouseId,
      name: this.formGroup.controls['name'].value,
      status: +this.formGroup.controls['status'].value === 1 ? true : false,
      description: this.formGroup.controls['description'].value,
      streetAddress: this.formGroup.controls['street'].value,
      city: this.formGroup.controls['city'].value,
      province: this.formGroup.controls['province'].value,
      country: this.formGroup.controls['country'].value,
    }

    if (!this.selectedWarehouseId) {
      this.warehouseService.create(model)
        .subscribe({
          next: (rse) => {
            if (rse.status === 200) {
              this.messageService.add({ key: 'toastKey1', severity: 'success', summary: 'Success', detail: 'Created successfully' });
              setTimeout(() => {
                this.router.navigate(['/branch']);
              }, 1000);
            }
          },
          error: (err) => {
            this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Error', detail: 'Failed to create' });
          }
        });
    } else {
      this.warehouseService.update(this.selectedWarehouseId, model)
        .subscribe({
          next: (rse) => {
            if (rse.status === 200) {
              this.messageService.add({ key: 'toastKey1', severity: 'success', summary: 'Success', detail: 'Updated successfully' });
              setTimeout(() => {
                this.router.navigate(['/branch']);
              }, 1000);
            }
          },
          error: (err) => {
            this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Error', detail: 'Failed to update' });
          }
        });
    }
  }

}



