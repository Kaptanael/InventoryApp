import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';

import { ProductTypeService } from '../../../_services/product-type.service';

@Component({
  selector: 'add-edit-product-type',
  templateUrl: './add-edit-product-type.component.html',
  styleUrl: './add-edit-product-type.component.css'
})
export class AddEditProductTypeComponent implements OnInit {

  public formGroup!: FormGroup;
  public selectedProductType: any = null;
  public selectedProductTypeId: string | undefined;
  public title: string | undefined;

  constructor(private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private messageService: MessageService,
    private productTypeService: ProductTypeService) {
    this.createFormGroup();
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => params.get('id') ? this.selectedProductTypeId = params.get('id')?.toString() : null);
    this.title = this.selectedProductTypeId ? 'Edit Product Type' : 'Add Product Type';
    this.getById();
  }

  createFormGroup(): void {
    this.formGroup = this.fb.group({
      name: ['', [this.noWhitespaceValidator, Validators.required, Validators.maxLength(50)]],
      status: ['1', Validators.required],
      description: ['', [this.noWhitespaceValidator, Validators.maxLength(200)]]      
    });
  }

  getById(): void {
    if (this.selectedProductTypeId) {
      this.productTypeService.getById(this.selectedProductTypeId).subscribe({
        next: (res) => {
          this.selectedProductType = res.body;
          this.fillUpFields();
        },
        error: (err) => {
          console.log(err);
        }
      });
    }
  }

  fillUpFields(): void{
    if (this.selectedProductType) {
      this.formGroup.patchValue({
        name: this.selectedProductType.name,
        status: this.getStringBoolean(this.selectedProductType.status),
        description: this.selectedProductType.description        
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
      id: this.selectedProductTypeId,
      name: this.formGroup.controls['name'].value,
      status: +this.formGroup.controls['status'].value === 1 ? true : false,
      description: this.formGroup.controls['description'].value     
    }    

    if (!this.selectedProductTypeId) {
      this.productTypeService.create(model)
        .subscribe({
          next: (rse) => {
            if (rse.status === 200) {              
              this.messageService.add({ key: 'toastKey1', severity: 'success', summary: 'Success', detail: 'Created successfully' });
              setTimeout(() => {
                this.router.navigate(['/product-type']);
              }, 1000);
            }
          },
          error: (err) => {
            this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Error', detail: 'Failed to create' });
          }
        });
    } else {
      this.productTypeService.update(this.selectedProductTypeId, model)
        .subscribe({
          next: (rse) => {
            if (rse.status === 200) {
              this.messageService.add({ key: 'toastKey1', severity: 'success', summary: 'Success', detail: 'Updated successfully' });
              setTimeout(() => {
                this.router.navigate(['/product-type']);
              },1000);              
            }
          },
          error: (err) => {
            this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Error', detail: 'Failed to update' });
          }
        });
    }
  }

}
