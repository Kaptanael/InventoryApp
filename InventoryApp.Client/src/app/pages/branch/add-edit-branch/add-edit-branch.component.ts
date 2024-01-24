import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BranchService } from '../../../_services/branch.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-add-edit-branch',
  templateUrl: './add-edit-branch.component.html',
  styleUrl: './add-edit-branch.component.css'
})
export class AddEditBranchComponent implements OnInit {

  public formGroup!: FormGroup;
  public selectedBranch: any = null;
  public selectedBranchId: string | undefined;
  public title: string | undefined;

  constructor(private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private messageService: MessageService,
    private branchService: BranchService) {
    this.createFormGroup();
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => params.get('id') ? this.selectedBranchId = params.get('id')?.toString() : null);
    this.title = this.selectedBranchId ? 'Edit Branch' : 'Add Branch';
    this.getById();
  }

  createFormGroup(): void {
    this.formGroup = this.fb.group({
      name: ['', [this.noWhitespaceValidator, Validators.required, Validators.maxLength(50)]],
      status: ['', Validators.required],
      description: ['', [this.noWhitespaceValidator, Validators.maxLength(200)]],
      street: ['', [this.noWhitespaceValidator, Validators.required, Validators.maxLength(200)]],
      city: ['', [this.noWhitespaceValidator, Validators.required, Validators.maxLength(50)]],
      province: ['', [this.noWhitespaceValidator, Validators.required, Validators.maxLength(50)]],
      country: ['', [this.noWhitespaceValidator, Validators.required, Validators.maxLength(50)]]
    });
  }

  getById(): void {
    if (this.selectedBranchId) {
      this.branchService.getById(this.selectedBranchId).subscribe({
        next: (res) => {
          this.selectedBranch = res.body;
          this.fillUpFields();
        },
        error: (err) => {
          console.log(err);
        }
      });
    }
  }

  fillUpFields(): void{
    if (this.selectedBranch) {
      this.formGroup.patchValue({
        name: this.selectedBranch.name,
        status: this.getStringBoolean(this.selectedBranch.status),
        description: this.selectedBranch.description,
        street: this.selectedBranch.streetAddress,
        city: this.selectedBranch.city,
        province: this.selectedBranch.province,
        country: this.selectedBranch.country,
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
      id: this.selectedBranchId,
      name: this.formGroup.controls['name'].value,
      status: +this.formGroup.controls['status'].value === 1 ? true : false,
      description: this.formGroup.controls['description'].value,
      streetAddress: this.formGroup.controls['street'].value,
      city: this.formGroup.controls['city'].value,
      province: this.formGroup.controls['province'].value,
      country: this.formGroup.controls['country'].value,
    }    

    if (!this.selectedBranchId) {
      this.branchService.create(model)
        .subscribe({
          next: (rse) => {
            if (rse.status === 200) {
              this.router.navigate(['/branch']);
              this.messageService.add({ key: 'toastKey1', severity: 'success', summary: 'Success', detail: 'Created successfully' });
            }
          },
          error: (err) => {
            this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Error', detail: 'Failed to create' });
          }
        });
    } else {
      this.branchService.update(this.selectedBranchId, model)
        .subscribe({
          next: (rse) => {
            if (rse.status === 200) {
              //this.router.navigate(['/branch']);
              this.messageService.add({ key: 'toastKey1', severity: 'success', summary: 'Success', detail: 'Updated successfully' });
            }
          },
          error: (err) => {
            this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Error', detail: 'Failed to update' });
          }
        });
    }
  }

}
