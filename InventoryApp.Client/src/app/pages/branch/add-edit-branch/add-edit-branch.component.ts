import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BranchService } from '../../../_services/branch.service';

@Component({
  selector: 'app-add-edit-branch',
  templateUrl: './add-edit-branch.component.html',
  styleUrl: './add-edit-branch.component.css'
})
export class AddEditBranchComponent {

  public formGroup!: FormGroup;
  public selectedBranch: any = {};
  public selectedBranchId: number | undefined;

  constructor(private fb: FormBuilder, private router: Router, private branchService: BranchService) {
    this.createFormGroup();
  }

  createFormGroup() {
    this.formGroup = this.fb.group({
      name: ['', Validators.compose([Validators.maxLength(50)])],
      description: ['', Validators.compose([Validators.maxLength(200)])],
      street: ['', Validators.compose([Validators.maxLength(200)])],
      city: ['', Validators.compose([Validators.maxLength(50)])],
      province: ['', Validators.compose([Validators.maxLength(50)])],
      country: ['', Validators.compose([Validators.maxLength(50)])]
    });
  }

  onSubmit() {
    const model = {
      id: this.selectedBranchId,
      name: this.formGroup.controls['name'].value,
      description: this.formGroup.controls['description'].value,
      streetAddress: this.formGroup.controls['street'].value,
      city: this.formGroup.controls['city'].value,
      province: this.formGroup.controls['province'].value,
      country: this.formGroup.controls['country'].value,
    }

    this.branchService.save(model)
      .subscribe({
        next: (rse) => {
          if (rse.status === 200) {
            this.router.navigate(['/branch']);
            //this.messageService.add({ key: 'toastKey1', severity: 'success', summary: 'Success', detail: 'Influenza vaccination form has been saved' });
          }
        },
        error: (err) => {
          //this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Error', detail: 'Failed to update influenza vaccination' });
        }
      });
  }

}
