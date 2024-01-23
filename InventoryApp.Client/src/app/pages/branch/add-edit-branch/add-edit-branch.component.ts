import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BranchService } from '../../../_services/branch.service';

@Component({
  selector: 'app-add-edit-branch',
  templateUrl: './add-edit-branch.component.html',
  styleUrl: './add-edit-branch.component.css'
})
export class AddEditBranchComponent implements OnInit {

  public formGroup!: FormGroup;
  public selectedBranch: any = null;
  public selectedBranchId: string | undefined;

  constructor(private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private branchService: BranchService) {
    this.createFormGroup();
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => params.get('id') ? this.selectedBranchId = params.get('id')?.toString() : null);
    this.getById();
  }

  createFormGroup() {
    this.formGroup = this.fb.group({
      name: ['', Validators.compose([Validators.required, Validators.maxLength(50)])],
      description: ['', Validators.compose([Validators.maxLength(200)])],
      street: ['', Validators.compose([Validators.required, Validators.maxLength(200)])],
      city: ['', Validators.compose([Validators.required, Validators.maxLength(50)])],
      province: ['', Validators.compose([Validators.required, Validators.maxLength(50)])],
      country: ['', Validators.compose([Validators.required, Validators.maxLength(50)])]
    });
  }

  getById() {
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

  fillUpFields() {
    if (this.selectedBranch) {
      this.formGroup.patchValue({
        name : this.selectedBranch.name,
        description: this.selectedBranch.description,
        street: this.selectedBranch.streetAddress,
        city: this.selectedBranch.city,
        province: this.selectedBranch.province,
        country: this.selectedBranch.country,
      })
    }
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
